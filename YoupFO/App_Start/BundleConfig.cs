using System.Web;
using System.Web.Optimization;

namespace ManageProductsAndCategories
{
    public class BundleConfig
    {
        // Pour plus d’informations sur le regroupement, rendez-vous sur http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Utilisez la version de développement de Modernizr pour développer et apprendre. Puis, lorsque vous êtes
            // prêt pour la production, utilisez l’outil de génération sur http://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/js_youp").Include(
            "~/Scripts/jquery.easing.1.3.js",
            "~/Scripts/bootstrap.min.js",
            "~/Scripts/jquery.flexslider-min.js",
            "~/Scripts/vibecom_slider.js",
            "~/Scripts/jquery.isotope.min.js",
            "~/Scripts/jquery.fitvids.js",
            "~/Scripts/audiojs/audio.min.js",
            "~/Scripts/jquery.countdown.min.js",
            "~/Scripts/cufon/cufon-yui.js",
            "~/Scripts/cufon/Oswald_400.font.js",
            "~/Scripts/cufon/Bebas_400.font.js",
            "~/Scripts/cufon/ColaborateLight_400.font.js",
            "~/Scripts/custom.js"
            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/bootstrap-responsive.css",
                        "~/Content/style.css",
                        "~/Content/site.css"));
        }
    }
}
