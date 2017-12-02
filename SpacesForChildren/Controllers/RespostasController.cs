using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SpacesForChildren.Models;

namespace SpacesForChildren.Controllers
{
    public class RespostasController : Controller
    {
        private SFCContext db = new SFCContext();

        // GET: Respostas
        public ActionResult Index()
        {
            var respostas = db.Respostas.Include(r => r.Instituicao);
            return View(respostas.ToList());
        }

        // GET: Respostas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resposta resposta = db.Respostas.Find(id);
            if (resposta == null)
            {
                return HttpNotFound();
            }
            return View(resposta);
        }

        // GET: Respostas/Create
        public ActionResult Create()
        {
            ViewBag.InstituicaoID = new SelectList(db.Instituicoes, "InstituicaoID", "InstituicaoNome");
            return View();
        }

        // POST: Respostas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RespostaID,RespostaDecisao,InstituicaoID")] Resposta resposta)
        {
            if (ModelState.IsValid)
            {
                db.Respostas.Add(resposta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InstituicaoID = new SelectList(db.Instituicoes, "InstituicaoID", "InstituicaoNome", resposta.InstituicaoID);
            return View(resposta);
        }

        // GET: Respostas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resposta resposta = db.Respostas.Find(id);
            if (resposta == null)
            {
                return HttpNotFound();
            }
            ViewBag.InstituicaoID = new SelectList(db.Instituicoes, "InstituicaoID", "InstituicaoNome", resposta.InstituicaoID);
            return View(resposta);
        }

        // POST: Respostas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RespostaID,RespostaDecisao,InstituicaoID")] Resposta resposta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resposta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InstituicaoID = new SelectList(db.Instituicoes, "InstituicaoID", "InstituicaoNome", resposta.InstituicaoID);
            return View(resposta);
        }

        // GET: Respostas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resposta resposta = db.Respostas.Find(id);
            if (resposta == null)
            {
                return HttpNotFound();
            }
            return View(resposta);
        }

        // POST: Respostas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resposta resposta = db.Respostas.Find(id);
            db.Respostas.Remove(resposta);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
