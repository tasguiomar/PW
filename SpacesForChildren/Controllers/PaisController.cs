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
    public class PaisController : Controller
    {
        private SFCContext db = new SFCContext();

        // GET: Pais
        [Autorizacao(Roles = "Pais, Admin")]
        public ActionResult Index()
        {
            return View(db.Pais.ToList());
        }

        // GET: Pais/Details/5
        [Autorizacao(Roles = "Admin, Pais")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pai pai = db.Pais.Find(id);
            if (pai == null)
            {
                return HttpNotFound();
            }
            return View(pai);
        }

        // GET: Pais/Create
        [Autorizacao(Roles = "Admin, Pais")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaiID,PaisNome,PaisCc,PaisNif,PaisTelemovel,PaisEmail")] Pai pai)
        {
            if (ModelState.IsValid)
            {
                pai.PaisEmail = User.Identity.GetUserName();
                db.Pais.Add(pai);
                db.SaveChanges();
                return RedirectToAction("../Home/Index");
            }

            return View(pai);
        }

        // GET: Pais/Edit/5
        [Autorizacao(Roles = "Admin, Pais")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pai pai = db.Pais.Find(id);
            if (pai == null)
            {
                return HttpNotFound();
            }
            return View(pai);
        }

        // POST: Pais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaiID,PaisNome,PaisCc,PaisNif,PaisTelemovel,PaisEmail")] Pai pai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pai);
        }

        // GET: Pais/Delete/5
        [Autorizacao(Roles = "Pais, Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pai pai = db.Pais.Find(id);
            if (pai == null)
            {
                return HttpNotFound();
            }
            return View(pai);
        }

        // POST: Pais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pai pai = db.Pais.Find(id);
            
            using (var db2 = new ApplicationDbContext())
            {
                if (this.User.IsInRole("Pais"))
                {
                    var user = db2.Users.Find(User.Identity.GetUserId());
                    db2.Users.Remove(user);
                    db2.SaveChanges();
                }
                else if (this.User.IsInRole("Admin"))
                {
                    var userID = db2.Users
                        .Where(m => m.Email == pai.PaisEmail)
                        .Select(m => m.Id)
                        .SingleOrDefault();
                    var user = db2.Users.Find(userID);
                    db2.Users.Remove(user);
                    db2.SaveChanges();
                }
            }

            db.Pais.Remove(pai);
            db.SaveChanges();

            if (this.User.IsInRole("Instituição"))
            {
                var ctx = Request.GetOwinContext();
                var authenticationManager = ctx.Authentication;
                authenticationManager.SignOut(DefaultAuthenticationTypes.App‌​licationCookie);

                Session.Clear();
                Session.Abandon();
            }

            return RedirectToAction("Index", "Home");
        }

        [Autorizacao(Roles = "Admin")]
        public ActionResult ConfirmaPais()
        {
            List<Pai> pais = new List<Pai>();
            foreach (var element in db.Pais)
            {
                using (var db2 = new ApplicationDbContext())
                {
                    var userID = db2.Users
                        .Where(m => m.Email == element.PaisEmail)
                        .Select(m => m.Id)
                        .SingleOrDefault();
                    var user = db2.Users.Find(userID);

                    if (user.EmailConfirmed == false)
                    {
                        pais.Add(element);
                    }
                }
            }

            return View(pais);
        }

        [Autorizacao(Roles = "Admin")]
        public ActionResult ConfPai(string email)
        {
            List<Pai> pais = new List<Pai>();
            var context = new ApplicationDbContext();
            foreach (var element in context.Users)
            {
                if (element.Email == email)
                {
                    element.EmailConfirmed = true;
                }
            }

            context.SaveChanges();

            return View("ConfirmaPais",pais);
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

