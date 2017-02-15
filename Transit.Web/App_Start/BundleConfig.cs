using System.Web;
using System.Web.Optimization;

namespace Transit.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/Theme").Include(
                      "~/Theme/vendors/bower_components/morris.js/morris.css",
                      "~/Theme/vendors/bower_components/datatables/media/css/jquery.dataTables.min.css",
                      "~/Theme/vendors/bower_components/jquery-toast-plugin/dist/jquery.toast.min.css",
                      "~/Theme/dist/css/style.css"));


            bundles.Add(new ScriptBundle("~/bundles/Theme").Include(
                      "~/Theme/vendors/bower_components/jquery/dist/jquery.min.js",
                      "~/Scripts/jquery.validate*",
                      "~/Theme/vendors/bower_components/bootstrap/dist/js/bootstrap.min.js",
                      "~/Theme/vendors/bower_components/datatables/media/js/jquery.dataTables.min.js",
                      "~/Theme/dist/js/jquery.slimscroll.js",
                      "~/Theme/vendors/bower_components/moment/min/moment.min.js",
                      "~/Theme/vendors/bower_components/simpleWeather/jquery.simpleWeather.min.js",
                      "~/Theme/dist/js/simpleweather-data.js",
                      "~/Theme/vendors/bower_components/waypoints/lib/jquery.waypoints.min.js",
                      "~/Theme/vendors/bower_components/Counter-Up/jquery.counterup.min.js",
                      "~/Theme/dist/js/dropdown-bootstrap-extended.js",
                      "~/Theme/vendors/jquery.sparkline/dist/jquery.sparkline.min.js",
                      "~/Theme/vendors/chart.js/Chart.min.js",
                      "~/Theme/vendors/bower_components/raphael/raphael.min.js",
                      "~/Theme/vendors/bower_components/morris.js/morris.min.js",
                      "~/Theme/dist/js/morris-data.js",
                      "~/Theme/vendors/bower_components/jquery-toast-plugin/dist/jquery.toast.min.js",
                      "~/Theme/dist/js/init.js",
                      "~/Theme/dist/js/dashboard-data.js"));
        }
    }
}
