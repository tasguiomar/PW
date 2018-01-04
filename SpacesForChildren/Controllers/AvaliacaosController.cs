using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SpacesForChildren.Models;
using Microsoft.AspNet.Identity;

namespace SpacesForChildren.Controllers
{
    public class AvaliacaosController : Controller
    {
        private SFCContext db = new SFCContext();

        // GET: Avaliacaos
        [Autorizacao]
        public ActionResult Index()
        {
            using (var db2 = new ApplicationDbContext())
            {
                var conta = db2.Users.Find(User.Identity.GetUserId());
                if (this.User.IsInRole("Instituição") || this.User.IsInRole("Pais"))
                {
                    if (conta.EmailConfirmed == false)
                    {
                        return RedirectToAction("ConfirmaConta", "Home");
                    }
                }
            }

            var avaliacoes = db.Avaliacoes.Include(a => a.Pai).Include(a => a.Servico);
            return View(avaliacoes.ToList());
        }

        // GET: Avaliacaos/Details/5
        [Autorizacao]
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

            using (var db2 = new ApplicationDbContext())
            {
                var conta = db2.Users.Find(User.Identity.GetUserId());
                if (this.User.IsInRole("Instituição") || this.User.IsInRole("Pais"))
                {
                    if (conta.EmailConfirmed == false)
                    {
                        return RedirectToAction("ConfirmaConta", "Home");
                    }
                }
            }

            return View(avaliacao);
        }

        // GET: Avaliacaos/Create
        [Autorizacao(Roles = "Pais, Admin")]
        public ActionResult Create()
        {
            using (var db2 = new ApplicationDbContext())
            {
                var conta = db2.Users.Find(User.Identity.GetUserId());
                if (this.User.IsInRole("Instituição") || this.User.IsInRole("Pais"))
                {
                    if (conta.EmailConfirmed == false)
                    {
                        return RedirectToAction("ConfirmaConta", "Home");
                    }
                }
            }

            ViewBag.PaiID = new SelectList(db.Pais, "PaiID", "PaisNome");
            ViewBag.ServicoID = new SelectList(db.Servicos, "ServicoID", "ServicosDescricao");
            return View();
        }

        // POST: Avaliacaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Autorizacao(Roles = "Pais, Admin")]
        public ActionResult Create([Bind(Include = "AvaliacaoID,AvaliacaoPreco,AvaliacaoLocalizacao,AvaliacaoAmbiente,AvaliacaoGeral,PaiID,ServicoID")] Avaliacao avaliacao)
        {
            if (ModelState.IsValid)
            {
                using (var db2 = new ApplicationDbContext())
                {
                    var conta = db2.Users.Find(User.Identity.GetUserId());
                    if (this.User.IsInRole("Instituição") || this.User.IsInRole("Pais"))
                    {
                        if (conta.EmailConfirmed == false)
                        {
                            return RedirectToAction("ConfirmaConta", "Home");
                        }
                    }
                }

                db.Avaliacoes.Add(avaliacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PaiID = new SelectList(db.Pais, "PaiID", "PaisNome", avaliacao.PaiID);
            ViewBag.ServicoID = new SelectList(db.Servicos, "ServicoID", "ServicosDescricao", avaliacao.ServicoID);
            return View(avaliacao);
        }

        // GET: Avaliacaos/Edit/5
        [Autorizacao(Roles = "Pais, Admin")]
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

            using (var db2 = new ApplicationDbContext())
            {
                var conta = db2.Users.Find(User.Identity.GetUserId());
                if (this.User.IsInRole("Instituição") || this.User.IsInRole("Pais"))
                {
                    if (conta.EmailConfirmed == false)
                    {
                        return RedirectToAction("ConfirmaConta", "Home");
                    }
                }
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
        [Autorizacao(Roles = "Instituição, Admin")]
        public ActionResult Edit([Bind(Include = "AvaliacaoID,AvaliacaoPreco,AvaliacaoLocalizacao,AvaliacaoAmbiente,AvaliacaoGeral,PaiID,ServicoID")] Avaliacao avaliacao)
        {
            if (ModelState.IsValid)
            {

                using (var db2 = new ApplicationDbContext())
                {
                    var conta = db2.Users.Find(User.Identity.GetUserId());
                    if (this.User.IsInRole("Instituição") || this.User.IsInRole("Pais"))
                    {
                        if (conta.EmailConfirmed == false)
                        {
                            return RedirectToAction("ConfirmaConta", "Home");
                        }
                    }
                }

                db.Entry(avaliacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PaiID = new SelectList(db.Pais, "PaiID", "PaisNome", avaliacao.PaiID);
            ViewBag.ServicoID = new SelectList(db.Servicos, "ServicoID", "ServicosDescricao", avaliacao.ServicoID);
            return View(avaliacao);
        }

        // GET: Avaliacaos/Delete/5
        [Autorizacao(Roles = "Admin, Pais")]
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

            using (var db2 = new ApplicationDbContext())
            {
                var conta = db2.Users.Find(User.Identity.GetUserId());
                if (this.User.IsInRole("Instituição") || this.User.IsInRole("Pais"))
                {
                    if (conta.EmailConfirmed == false)
                    {
                        return RedirectToAction("ConfirmaConta", "Home");
                    }
                }
            }

            return View(avaliacao);
        }

        // POST: Avaliacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Autorizacao(Roles = "Admin, Instituição")]
        public ActionResult DeleteConfirmed(int id)
        {
            Avaliacao avaliacao = db.Avaliacoes.Find(id);

            using (var db2 = new ApplicationDbContext())
            {
                var conta = db2.Users.Find(User.Identity.GetUserId());
                if (this.User.IsInRole("Instituição") || this.User.IsInRole("Pais"))
                {
                    if (conta.EmailConfirmed == false)
                    {
                        return RedirectToAction("ConfirmaConta", "Home");
                    }
                }
            }

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

