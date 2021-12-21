using System.Web;
using System.Web.Optimization;

namespace HitExercise.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/modernizr-*",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/Datatables/jquery.dataTables.js",
                        "~/Scripts/Datatables/dataTables.bootstrap.js",
                        "~/Scripts/bootbox*"));

            bundles.Add(new ScriptBundle("~/bundles/index").Include(
                        "~/Scripts/SuppliersIndex.js"));

            bundles.Add(new ScriptBundle("~/bundles/InactiveSup").Include(
                        "~/Scripts/InactiveSup.js"));





            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/Datatables/css/dataTables.bootstrap.css"));


        }
    }
}
