using System.Web;
using System.Web.Optimization;

namespace CampusAcademiaApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //       "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                      "~/Scripts/jquery-{version}.js",
                       "~/Scripts/jquery-ui.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
            //I create Bundle of js for Admin Layout
            bundles.Add(new ScriptBundle("~/bundles/Adminbootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/jquery.uploadify.js",
                      "~/Scripts/adminlayout/jQuery-2.1.4.min.js",
                      "~/Scripts/adminlayout/raphael-min.js",
                      "~/Scripts/adminlayout/morris.js",
                      "~/Scripts/adminlayout/jquery.sparkline.js",
                      "~/Scripts/adminlayout/jquery-jvectormap-1.2.2.min.js",
                      "~/Scripts/adminlayout/jquery-jvectormap-world-mill-en.js",
                      "~/Scripts/adminlayout/jquery.knob.js",
                      "~/Scripts/adminlayout/moment.js",
                      "~/Scripts/adminlayout/bootstrap3-wysihtml5.all.js",
                      "~/Scripts/adminlayout/jquery.slimscroll.js",
                      "~/Scripts/adminlayout/fastclick.js",
                      "~/Scripts/adminlayout/app.js",
                      "~/Scripts/adminlayout/dashboard.js",
                      "~/Scripts/adminlayout/demo.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstraplogin").Include(
                    "~/Scripts/bootstrap.js",
                    "~/Scripts/adminlayout/jQuery-2.1.4.min.js",
                    "~/Scripts/adminlayout/icheck.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/jquery-ui.min.css",     
                "~/Content/jquery-ui.structure.min.css",
                       "~/Content/jquery-ui.theme.min.css"

                      ));
            //I create Bundle of css for Admin Layout

            bundles.Add(new StyleBundle("~/Content/Admincss").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/font-awesome.css",
                       "~/Content/ionicons.css",
                      "~/Content/AdminLTE.css",
                      "~/Content/_all-skins.css",
                      "~/Content/blue.css",
                      "~/Content/morris.css",
                      "~/Content/uploadify.css",
                      //"~/Content/jquery-ui.min.css",
                      "~/Content/jquery-jvectormap-1.2.2.css",
                      "~/Content/bootstrap3-wysihtml5.css"));
            bundles.Add(new StyleBundle("~/Content/Admincsslogin").Include(
                     "~/Content/bootstrap.css",
                      "~/Content/font-awesome.css",
                       "~/Content/ionicons.css",
                      "~/Content/AdminLTE.css",
                      "~/Content/blue.css"));

                      // Front End CSS

                       bundles.Add(new StyleBundle("~/Content/frontEndcss").Include(
                      "~/Content/frontendCSS/bootstrap.min.css",
                      "~/Content/frontendCSS/font-awesome.min.css",
                       "~/Content/frontendCSS/superslides.css",
                      "~/Content/frontendCSS/slick.css",
                       "~/Content/frontendCSS/jquery.circliful.css",
                       "~/Content/frontendCSS/animate.css",
                        "~/Content/frontendCSS/jquery.tosrus.all.css",
                         "~/Content/frontendCSS/default-theme.css",
                      "~/Content/frontendCSS/style.css"
                      ));

            // Front End JS
                       bundles.Add(new ScriptBundle("~/bundles/frontEndJS").Include(
                                
                                "~/Scripts/frontEnd/jquery.min.js",
                              // "~/Scripts/frontEnd/queryloader2.min.js",
                                  "~/Scripts/frontEnd/wow.min.js",
                                   "~/Scripts/frontEnd/bootstrap.min.js",
                                    "~/Scripts/frontEnd/slick.min.js",
                                    "~/Scripts/frontEnd/jquery.easing.1.3.js",
                                    "~/Scripts/frontEnd/jquery.animate-enhanced.min.js",
                           //"~/Scripts/frontEnd/jQuery-2.1.4.min.js",
                                "~/Scripts/frontEnd/jquery.superslides.min.js",
                                 "~/Scripts/frontEnd/jquery.circliful.js",
                                "~/Scripts/frontEnd/jquery.tosrus.min.all.js",

                                 "~/Scripts/frontEnd/custom.js"
                                ));

        }
    }
}
