﻿using System.Web;
using System.Web.Optimization;

namespace ElmahDemoApp
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

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/font-awesome.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquerydatatables").Include(
                "~/Scripts/datatables.min.js",
                "~/Scripts/datatables.customize.js"));

            bundles.Add(new StyleBundle("~/Content/jquerydatatables").Include(
                "~/Content/datatables.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/areyousure").Include(
                "~/Scripts/jquery.are.you.sure.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootbox").Include(
               "~/Scripts/bootbox.min.js"));
        }
    }
}
