using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transit.Commons;
using Transit.Web.Models;

namespace Transit.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();

            model.Title = "Home";
            model.BreadCrumbs = new List<Link>{
                new Link() { Text="Dashboard" },
                new Link() { Text="Home", URL="home" },
                new Link() { Text="Dashboard", URL="home" },
            };

            return View(model);
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