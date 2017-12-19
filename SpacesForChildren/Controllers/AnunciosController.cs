﻿using System;
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
    public class AnunciosController : Controller
    {
        private SFCContext db = new SFCContext();

        // GET: Anuncios
        public ActionResult Index()
        {
            var user = User.Identity.GetUserName();
            var userId = db.Instituicoes
                .Where(m => m.InstituicaoEmail == user)
                .Select(m => m.InstituicaoID)
                .SingleOrDefault();

            ViewBag.instituicao = userId;
            
            var anuncios = db.Anuncios.Include(a => a.Servico);
            return View(anuncios.ToList());
        }

        // GET: Anuncios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anuncio anuncio = db.Anuncios.Find(id);
            if (anuncio == null)
            {
                return HttpNotFound();
            }
            var user = User.Identity.GetUserName();
            var userId = db.Instituicoes
                .Where(m => m.InstituicaoEmail == user)
                .Select(m => m.InstituicaoID)
                .SingleOrDefault();
            ViewBag.instituicao = userId;
            return View(anuncio);
        }

        // GET: Anuncios/Create
        public ActionResult Create()
        {
            var user = User.Identity.GetUserName();
            var userId = db.Instituicoes
                .Where(m => m.InstituicaoEmail == user)
                .Select(m => m.InstituicaoID)
                .SingleOrDefault();
            
            ViewBag.ServicoID = new SelectList(db.Servicos.Where(x => x.InstituicaoID == userId), "ServicoID", "ServicosDescricao");
            return View();
        }

        // POST: Anuncios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AnuncioID,AnuncioTitulo,AnuncioDescricao,AnuncioData,InstituicaoID,ServicoID")] Anuncio anuncio)
        {
            if (ModelState.IsValid)
            {
                var user = User.Identity.GetUserName();
                var userId = db.Instituicoes
                    .Where(m => m.InstituicaoEmail == user)
                    .Select(m => m.InstituicaoID)
                    .SingleOrDefault();

                db.Anuncios.Add(anuncio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.InstituicaoID = new SelectList(db.Instituicoes, "InstituicaoID", "InstituicaoNome", anuncio.InstituicaoID);
            ViewBag.ServicoID = new SelectList(db.Servicos, "ServicoID", "ServicosDescricao", anuncio.ServicoID);
            return View(anuncio);
        }

        // GET: Anuncios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anuncio anuncio = db.Anuncios.Find(id);
            if (anuncio == null)
            {
                return HttpNotFound();
            }
            ViewBag.ServicoID = new SelectList(db.Servicos, "ServicoID", "ServicosDescricao", anuncio.ServicoID);
            return View(anuncio);
        }

        // POST: Anuncios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AnuncioID,AnuncioTitulo,AnuncioDescricao,AnuncioData,InstituicaoID,ServicoID")] Anuncio anuncio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anuncio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(anuncio);
        }

        // GET: Anuncios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anuncio anuncio = db.Anuncios.Find(id);
            if (anuncio == null)
            {
                return HttpNotFound();
            }
            return View(anuncio);
        }

        // POST: Anuncios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Anuncio anuncio = db.Anuncios.Find(id);
            db.Anuncios.Remove(anuncio);
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
