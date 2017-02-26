using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Transit.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "Register",
              url: "register",
              defaults: new { controller = "Account", action = "Register" }
              );

            routes.MapRoute(
              name: "Login",
              url: "login",
              defaults: new { controller = "Account", action = "Login" }
              );

            routes.MapRoute(
              name: "About",
              url: "about-us",
              defaults: new { controller = "Home", action = "About" }
              );

            routes.MapRoute(
              name: "Contact",
              url: "contact-us",
              defaults: new { controller = "Home", action = "Contact" }
              );

            routes.MapRoute(
              name: "Privacy Policy",
              url: "privacy-policy",
              defaults: new { controller = "Home", action = "PrivacyPolicy" }
              );

            routes.MapRoute(
              name: "TermsAndConditions",
              url: "terms-and-conditions",
              defaults: new { controller = "Home", action = "TermsAndConditions" }
              );

            routes.MapRoute(
              name: "FAQs",
              url: "faqs",
              defaults: new { controller = "Home", action = "FAQs" }
              );

            //routes.MapRoute(
            //  name: "VehicleTypes",
            //  url: "admin/vehicle-types",
            //  defaults: new { controller = "VehicleTypes", action = "Index" }
            //  );

            routes.MapRoute(
              name: "VehicleTypes",
              url: "admin/vehicle-types/{action}",
              defaults: new { controller = "VehicleTypes", action = "Index" }
              );

            routes.MapRoute(
              name: "Cities",
              url: "admin/cities/{action}",
              defaults: new { controller = "Cities", action = "Index" }
              );

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Home", action = "Index" }
              );

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //  );
        }
    }
}
