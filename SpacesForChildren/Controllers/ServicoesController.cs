using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SpacesForChildren.Models;
using System.Web.Security;
using Microsoft.AspNet.Identity;

namespace SpacesForChildren.Controllers
{
    public class ServicoesController : Controller
    {
        private SFCContext db = new SFCContext();

        // GET: Servicoes
        public ActionResult Index()
        {
            var servicos = db.Servicos.Include(s => s.Instituicao);
            var user = User.Identity.GetUserName();
            var userId = db.Instituicoes
                .Where(m => m.InstituicaoEmail == user)
                .Select(m => m.InstituicaoID)
                .SingleOrDefault();
            ViewBag.instituicao = userId.ToString();
            return View(servicos.ToList());
        }

        // GET: Servicoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servico servico = db.Servicos.Find(id);
            if (servico == null)
            {
                return HttpNotFound();
            }
            var user = User.Identity.GetUserName();
            var userId = db.Instituicoes
                .Where(m => m.InstituicaoEmail == user)
                .Select(m => m.InstituicaoID)
                .SingleOrDefault();
            ViewBag.instituicao = userId.ToString();
            return View(servico);
        }

        // GET: Servicoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Servicoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServicoID,ServicosDescricao,ServicosPreco,ServicosTipo,InstituicaoID")] Servico servico)
        {
            if (ModelState.IsValid)
            {
                var user = User.Identity.GetUserName();
                var userId = db.Instituicoes
                    .Where(m => m.InstituicaoEmail == user)
                    .Select(m => m.InstituicaoID)
                    .SingleOrDefault();

                servico.InstituicaoID = userId;
                db.Servicos.Add(servico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(servico);
        }

        // GET: Servicoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servico servico = db.Servicos.Find(id);
            if (servico == null)
            {
                return HttpNotFound();
            }
            //ViewBag.InstituicaoID = new SelectList(db.Instituicoes, "InstituicaoID", "InstituicaoNome", servico.InstituicaoID);
            return View(servico);
        }

        // POST: Servicoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServicoID,ServicosDescricao,ServicosPreco,ServicosTipo,InstituicaoID")] Servico servico)
        {
            if (ModelState.IsValid)
            {
                var user = User.Identity.GetUserName();
                var userId = db.Instituicoes
                    .Where(m => m.InstituicaoEmail == user)
                    .Select(m => m.InstituicaoID)
                    .SingleOrDefault();

                servico.InstituicaoID = userId;
                db.Entry(servico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servico);
        }

        // GET: Servicoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servico servico = db.Servicos.Find(id);
            if (servico == null)
            {
                return HttpNotFound();
            }
            return View(servico);
        }

        // POST: Servicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Servico servico = db.Servicos.Find(id);
            db.Servicos.Remove(servico);
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
