using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpacesForChildren.Controllers
{
    public class AnuncioController : Controller
    {
        // GET: Anuncioontroller
        public ActionResult Index()
        {
            return View();
        }

        // GET: Anuncioontroller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Anuncioontroller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Anuncioontroller/Create
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

        // GET: Anuncioontroller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Anuncioontroller/Edit/5
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

        // GET: Anuncioontroller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Anuncioontroller/Delete/5
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
