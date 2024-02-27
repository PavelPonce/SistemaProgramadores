using System.Web;
using System.Web.Optimization;

namespace SistemaAcademiaProgramadores
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //////////////////////// INSPINIA BUNDLES /////////////////////////
            bundles.Add(new StyleBundle("~/Content/HTML5_Full_Version/css/bootstrap.css").Include(
                      "~/Content/HTML5_Full_Version/css/bootstrap.css"));
            bundles.Add(new StyleBundle("~/Content/HTML5_Full_Version/font-awesome/css/font-awesome.css").Include(
                      "~/Content/HTML5_Full_Version/font-awesome/css/font-awesome.css"));
            bundles.Add(new StyleBundle("~/Content/HTML5_Full_Version/css/animate.css").Include(
                      "~/Content/HTML5_Full_Version/css/animate.css"));
            bundles.Add(new StyleBundle("~/Content/HTML5_Full_Version/css/style.css").Include(
                      "~/Content/HTML5_Full_Version/css/style.css")); 
            
            bundles.Add(new ScriptBundle("~/bundles/Content/HTML5_Full_Version/js/jquery-3.1.1.min.js").Include(
                        "~/Content/HTML5_Full_Version/js/jquery-3.1.1.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/Content/HTML5_Full_Version/js/popper.min.js").Include(
            "~/Content/HTML5_Full_Version/js/popper.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/Content/HTML5_Full_Version/js/bootstrap.js").Include(
            "~/Content/HTML5_Full_Version/js/bootstrap.js"));
            bundles.Add(new ScriptBundle("~/bundles/Content/HTML5_Full_Version/js/plugins/metisMenu/jquery.metisMenu.js").Include(
            "~/Content/HTML5_Full_Version/js/plugins/metisMenu/jquery.metisMenu.js"));
            bundles.Add(new ScriptBundle("~/bundles/Content/HTML5_Full_Version/js/plugins/slimscroll/jquery.slimscroll.min.js").Include(
            "~/Content/HTML5_Full_Version/js/plugins/slimscroll/jquery.slimscroll.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/Content/HTML5_Full_Version/js/inspinia.js").Include(
            "~/Content/HTML5_Full_Version/js/inspinia.js"));
            bundles.Add(new ScriptBundle("~/bundles/Content/HTML5_Full_Version/js/plugins/pace/pace.min.js").Include(
            "~/Content/HTML5_Full_Version/js/plugins/pace/pace.min.js"));
            //////////////////////// INSPINIA BUNDLES /////////////////////////

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
