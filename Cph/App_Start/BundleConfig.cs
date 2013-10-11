using System.Web;
using System.Web.Optimization;

namespace Cph
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;

            // jquery
            bundles.Add(new ScriptBundle("~/bundles/jquery",
                cdnPath: "//ajax.googleapis.com/ajax/libs/jquery/2.0.3/jquery.min.js").Include(
                "~/js/jquery-{version}.js"
            ));

            // js
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                "~/js/jquery.unobtrusive*",
                "~/js/jquery.validate*"
            ));

            // css
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/css/site.css"
            ));
        }
    }
}