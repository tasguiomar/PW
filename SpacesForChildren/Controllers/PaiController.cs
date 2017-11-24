using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpacesForChildren.Controllers
{
    public class PaiController : Controller
    {
        // GET: Pai
        public ActionResult Index()
        {
            return View();
        }

        // GET: Pai/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pai/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pai/Create
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

        // GET: Pai/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pai/Edit/5
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

        // GET: Pai/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pai/Delete/5
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
