using System.Web;
using System.Web.Optimization;

namespace ControleHoras.APRESENTACAO
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //JS

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/mask").Include(
                        "~/Scripts/jquery.mask.js"));

            bundles.Add(new ScriptBundle("~/bundles/maskMoney").Include(
                        "~/Scripts/jquery.maskMoney.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/chosen").Include(
                        "~/Scripts/chosen.jquery.js",
                        "~/Scripts/chosen.proto.js"));

            bundles.Add(new ScriptBundle("~/bundles/datetimepicker").Include(
                        "~/Scripts/jquery.datetimepicker.full.min.js",
                        "~/Scripts/datepicker-pt-BR.js"));

            bundles.Add(new ScriptBundle("~/bundles/digitalClock").Include(
                        "~/Scripts/digitalClock.js"));

            bundles.Add(new ScriptBundle("~/bundles/msgBox").Include(
                        "~/Scripts/messagebox.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
                "~/Scripts/moment.min.js",
                "~/Scripts/moment-with-locales.min.js"));

            //ESTILOS CSS

            bundles.Add(new StyleBundle("~/styles/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/styles/chosen").Include(
                      "~/Content/chosen.css"));

            bundles.Add(new StyleBundle("~/styles/datetimepicker").Include(
                      "~/Content/jquery.datetimepicker.min.css"));

            bundles.Add(new StyleBundle("~/styles/digitalClock").Include(
                      "~/Content/clock.css"));

            bundles.Add(new StyleBundle("~/styles/msgBox").Include(
                      "~/Content/messagebox.css"));

            bundles.Add(new StyleBundle("~/styles/jqueryui").Include(
                      "~/Content/jquery-ui/jquery-ui.min.css",
                      "~/Content/jquery-ui/jquery-ui.structure.min.css",
                      "~/Content/jquery-ui/jquery-ui.theme.min.css"));

        }
    }
}
