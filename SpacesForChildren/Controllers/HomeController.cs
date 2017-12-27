using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Microsoft.AspNet.Identity;

namespace SpacesForChildren.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.user = User.Identity.GetUserName();
            return View();
        }

        public ActionResult ConfirmaConta()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
    }
}