using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SpacesForChildren.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Web.Security;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SpacesForChildren.Controllers
{
    public class InstituicaosController : Controller
    {
        private SFCContext db = new SFCContext();

        // GET: Instituicaos
        public ActionResult Index(string option, string search, int? pageNumber)
        {
            if (option == "Morada")
            {
                //Index action method will return a view with a student records based on what a user specify the value in textbox  
                return View(db.Instituicoes.Where(x => x.InstituicaoMorada == search || search == null).ToList());
            }
            else if (option == "Cidade")
            {
                return View(db.Instituicoes.Where(x => x.InstituicaoCidade == search || search == null).ToList());
            }

            return View(db.Instituicoes.ToList());
        }


        // GET: Instituicaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instituicao instituicao = db.Instituicoes.Find(id);
            if (instituicao == null)
            {
                return HttpNotFound();
            }
            return View(instituicao);
        }

        // GET: Instituicaos/Create
        [Autorizacao(Roles = "Instituição, Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Instituicaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InstituicaoID,InstituicaoTipo,InstituicaoNome,InstituicaoEmail,InstituicaoTelefone,InstituicaoCidade,InstituicaoMorada")] Instituicao instituicao)
        {
            if (ModelState.IsValid)
            {
                instituicao.InstituicaoEmail = User.Identity.GetUserName();
                db.Instituicoes.Add(instituicao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(instituicao);
        }

        // GET: Instituicaos/Edit/5
        [Autorizacao(Roles = "Instituição, Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instituicao instituicao = db.Instituicoes.Find(id);
            if (instituicao == null)
            {
                return HttpNotFound();
            }
            return View(instituicao);
        }

        // POST: Instituicaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InstituicaoID,InstituicaoTipo,InstituicaoNome,InstituicaoEmail,InstituicaoTelefone,InstituicaoCidade,InstituicaoMorada")] Instituicao instituicao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instituicao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(instituicao);
        }

        // GET: Instituicaos/Delete/5
        [Autorizacao(Roles = "Instituição, Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instituicao instituicao = db.Instituicoes.Find(id);
            if (instituicao == null)
            {
                return HttpNotFound();
            }
            return View(instituicao);
        }

        // POST: Instituicaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instituicao instituicao = db.Instituicoes.Find(id);

            using (var db2 = new ApplicationDbContext())
            {
                if (this.User.IsInRole("Instituição"))
                {
                    var user = db2.Users.Find(User.Identity.GetUserId());
                    db2.Users.Remove(user);
                    db2.SaveChanges();
                }
                else if (this.User.IsInRole("Admin"))
                {
                    var userID = db2.Users
                        .Where(m => m.Email == instituicao.InstituicaoEmail)
                        .Select(m => m.Id)
                        .SingleOrDefault();
                    var user = db2.Users.Find(userID);
                    db2.Users.Remove(user);
                    db2.SaveChanges();
                }
            }

            db.Instituicoes.Remove(instituicao);
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

        
        public ActionResult ConfirmaInstituicao()
        {
            List<Instituicao> instituicoes = new List<Instituicao>();
            foreach (var element in db.Instituicoes)
            {
                using (var db2 = new ApplicationDbContext())
                {
                    var userID = db2.Users
                        .Where(m => m.Email == element.InstituicaoEmail)
                        .Select(m => m.Id)
                        .SingleOrDefault();
                    var user = db2.Users.Find(userID);

                    if (user.EmailConfirmed == false)
                    {
                        instituicoes.Add(element);
                    }
                }
            }

            return View(instituicoes);
        }

        public ActionResult ConfInst(string email)
        {
            List<Instituicao> instituicoes = new List<Instituicao>();
            var context = new ApplicationDbContext();
            foreach (var element in context.Users)
            {
                if (element.Email == email)
                {
                    element.EmailConfirmed = true;
                }
            }

            context.SaveChanges();

            return View("ConfirmaInstituicao",instituicoes);
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

