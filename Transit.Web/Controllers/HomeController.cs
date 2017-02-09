using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transit.Web.Models;

namespace Transit.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //HomeViewModel model = new HomeViewModel();

            //{
            //    model.Title = "Home";
            //    model.BreadCrumbs.Add("Home");
            //    model.BreadCrumbs.Add("Dashboard");
            //}

            ViewBag.King = "Home";
            ViewBag.BreadCrumbs = new List<string>{
                "Home",
                "Dashboard"
            };
            return View(new HomeViewModel());
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