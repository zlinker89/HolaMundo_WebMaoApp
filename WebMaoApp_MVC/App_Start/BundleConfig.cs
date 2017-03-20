using System.Web;
using System.Web.Optimization;

namespace WebMaoApp_MVC
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/FilesJS").Include(
                "~/Scripts/vendor.a0681ce4.js",
                "~/Scripts/loading-bar.js",
                "~/Scripts/scripts.8045f803.js",
                "~/Scripts/TokenService.js",
                "~/Scripts/TokenController.js"
                      ));
            bundles.Add(new StyleBundle("~/styles/FileCSS").Include(
                      "~/styles/font-awesome.min.css",
                      "~/styles/vendor.f9eeb159.css",
                      "~/styles/main.76fb8b83.css",
                      "~/styles/loading-bar.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
