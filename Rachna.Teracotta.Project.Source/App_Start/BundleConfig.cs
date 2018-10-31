using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Rachna.Teracotta.Project.Source
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/stylesTheme2").Include(
                               "~/appfiles/frontend2/style.css",
                               "~/appfiles/frontend2/css/custom.css"));

            bundles.Add(new ScriptBundle("~/bundles/scriptsTheme2").Include(
                               "~/appfiles/frontend2/js/vendor/modernizr-3.6.0.min.js",
                               "~/appfiles/frontend2/js/vendor/jquery-3.3.1.min.js",
                               "~/appfiles/frontend2/js/popper.min.js",
                               "~/appfiles/frontend2/js/bootstrap.min.js",
                               "~/appfiles/frontend2/js/plugins.js",
                               "~/appfiles/frontend2/js/main.js",
                               "~/appfiles/frontend2/js/jquery.tmpl.min.js",
                               "~/appfiles/frontend2/js/messi.min.js",
                               "~/appfiles/frontend2/js/jquery.blockUI.js"));

            bundles.Add(new ScriptBundle("~/bundles/global").Include(
                               "~/content/admin/js/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/globalhead").Include(
                               "~/content/admin/js/plugins/nicescroll/jquery.nicescroll.min.js",
                               "~/content/admin/js/plugins/imagesLoaded/jquery.imagesloaded.min.js",
                               "~/content/admin/js/plugins/jquery-ui/jquery-ui.js",
                               "~/content/admin/js/plugins/slimscroll/jquery.slimscroll.min.js",
                               "~/content/admin/js/plugins/bootbox/jquery.bootbox.js",
                               "~/content/admin/js/plugins/momentjs/jquery.moment.min.js",
                               "~/content/admin/js/plugins/momentjs/moment-range.min.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}