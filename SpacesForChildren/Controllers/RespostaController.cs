using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpacesForChildren.Controllers
{
    public class RespostaController : Controller
    {
        // GET: Resposta
        public ActionResult Index()
        {
            return View();
        }

        // GET: Resposta/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Resposta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Resposta/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Resposta/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Resposta/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Resposta/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Resposta/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
