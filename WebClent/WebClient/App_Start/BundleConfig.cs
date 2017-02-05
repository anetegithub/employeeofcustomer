using System.Web;
using System.Web.Optimization;

namespace WebClient
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/scripts/material").Include(
                        "~/materialize/js/materialize.js",
                        "~/Scripts/app.js"));

            bundles.Add(new StyleBundle("~/css/material").Include(
                "~/materialize/css/materialize.css",
                "~/css/custom.css"));
        }
    }
}
