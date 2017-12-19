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
    public class PedidoesController : Controller
    {
        private SFCContext db = new SFCContext();

        // GET: Pedidoes
        public ActionResult Index()
        {
            var pedidos = db.Pedidos.Include(p => p.Anuncio);
            var user = User.Identity.GetUserName();
            var userId = db.Pais
                .Where(m => m.PaisEmail == user)
                .Select(m => m.PaiID)
                .SingleOrDefault();

            ViewBag.pai = userId;

            var user2 = User.Identity.GetUserName();
            var userId2 = db.Instituicoes
                .Where(m => m.InstituicaoEmail == user2)
                .Select(m => m.InstituicaoID)
                .SingleOrDefault();

            ViewBag.inst = userId2;

            return View(pedidos.ToList());
        }

        // GET: Pedidoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidos.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            var user = User.Identity.GetUserName();
            var userId = db.Pais
                .Where(m => m.PaisEmail == user)
                .Select(m => m.PaiID)
                .SingleOrDefault();
            ViewBag.pai = userId.ToString();
            return View(pedido);
        }

        // GET: Pedidoes/Create
        public ActionResult Create()
        {
            var user = User.Identity.GetUserName();
            var userId = db.Pais
                .Where(m => m.PaisEmail == user)
                .Select(m => m.PaiID)
                .SingleOrDefault();
            
            ViewBag.PaiID = userId;
            ViewBag.AnuncioID = new SelectList(db.Anuncios, "AnuncioID", "AnuncioTitulo");
            ViewBag.RespostaID = null;
            return View();
        }

        // POST: Pedidoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PedidoID,AnuncioID,RespostaID")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                var user = User.Identity.GetUserName();
                var userId = db.Pais
                    .Where(m => m.PaisEmail == user)
                    .Select(m => m.PaiID)
                    .SingleOrDefault();

                pedido.Resposta = Resp.Espera;
                pedido.PaiID = userId;
                db.Pedidos.Add(pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AnuncioID = new SelectList(db.Anuncios, "AnuncioID", "AnuncioTitulo", pedido.AnuncioID);
            return View(pedido);
        }

        // GET: Pedidoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidos.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnuncioID = new SelectList(db.Anuncios, "AnuncioID", "AnuncioTitulo", pedido.AnuncioID);
            ViewBag.PaiID = new SelectList(db.Pais, "PaiID", "PaisNome", pedido.PaiID);
            ViewBag.Resposta = new SelectList(Enum.GetValues(typeof(Resp)));
            return View(pedido);
        }

        // POST: Pedidoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PedidoID,AnuncioID,PaiID,Resposta")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnuncioID = new SelectList(db.Anuncios, "AnuncioID", "AnuncioTitulo", pedido.AnuncioID);
            return View(pedido);
        }

        // GET: Pedidoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidos.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: Pedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedido pedido = db.Pedidos.Find(id);
            db.Pedidos.Remove(pedido);
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
