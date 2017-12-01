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
    public class AvaliacaosController : Controller
    {
        private SFCContext db = new SFCContext();

        // GET: Avaliacaos
        public ActionResult Index()
        {
            var avaliacoes = db.Avaliacoes.Include(a => a.Pai).Include(a => a.Servico);
            return View(avaliacoes.ToList());
        }

        // GET: Avaliacaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliacao avaliacao = db.Avaliacoes.Find(id);
            if (avaliacao == null)
            {
                return HttpNotFound();
            }
            return View(avaliacao);
        }

        // GET: Avaliacaos/Create
        public ActionResult Create()
        {
            ViewBag.PaiID = new SelectList(db.Pais, "PaiID", "PaisNome");
            ViewBag.ServicoID = new SelectList(db.Servicos, "ServicoID", "ServicosDescricao");
            return View();
        }

        // POST: Avaliacaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AvaliacaoID,AvaliacaoPreco,AvaliacaoLocalizacao,AvaliacaoAmbiente,AvaliacaoGeral,PaiID,ServicoID")] Avaliacao avaliacao)
        {
            if (ModelState.IsValid)
            {
                db.Avaliacoes.Add(avaliacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PaiID = new SelectList(db.Pais, "PaiID", "PaisNome", avaliacao.PaiID);
            ViewBag.ServicoID = new SelectList(db.Servicos, "ServicoID", "ServicosDescricao", avaliacao.ServicoID);
            return View(avaliacao);
        }

        // GET: Avaliacaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliacao avaliacao = db.Avaliacoes.Find(id);
            if (avaliacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.PaiID = new SelectList(db.Pais, "PaiID", "PaisNome", avaliacao.PaiID);
            ViewBag.ServicoID = new SelectList(db.Servicos, "ServicoID", "ServicosDescricao", avaliacao.ServicoID);
            return View(avaliacao);
        }

        // POST: Avaliacaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AvaliacaoID,AvaliacaoPreco,AvaliacaoLocalizacao,AvaliacaoAmbiente,AvaliacaoGeral,PaiID,ServicoID")] Avaliacao avaliacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(avaliacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PaiID = new SelectList(db.Pais, "PaiID", "PaisNome", avaliacao.PaiID);
            ViewBag.ServicoID = new SelectList(db.Servicos, "ServicoID", "ServicosDescricao", avaliacao.ServicoID);
            return View(avaliacao);
        }

        // GET: Avaliacaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliacao avaliacao = db.Avaliacoes.Find(id);
            if (avaliacao == null)
            {
                return HttpNotFound();
            }
            return View(avaliacao);
        }

        // POST: Avaliacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Avaliacao avaliacao = db.Avaliacoes.Find(id);
            db.Avaliacoes.Remove(avaliacao);
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
