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
            bundles.Add(new ScriptBundle("~/bundles/javascriptfiles").Include(
                "~/appfiles/frontend/js/jquery.js",
                "~/appfiles/frontend/jquery-ui/jquery-ui.js",
                "~/appfiles/frontend/js/bootstrap-select.js",
                "~/appfiles/frontend/js/bootstrap.js",
                "~/appfiles/frontend/js/owl.carousel.js",
                "~/appfiles/frontend/js/plugins.js",
                "~/appfiles/frontend/js/main.js",
                "~/appfiles/frontend/js/jquery.tmpl.min.js",
                "~/appfiles/frontend/js/messi.min.js",
                "~/appfiles/frontend/js/imagezoom.js",
                "~/appfiles/frontend/js/easy-responsive-tabs.js",
                "~/appfiles/frontend/js/jquery.flexslider.js",
                "~/appfiles/frontend/js/jquery.blockUI.js"
              ));

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

            bundles.Add(new StyleBundle("~/bundles/feglobal").Include(
                               "~/appfiles/frontend/css/bootstrap.css",
                               "~/appfiles/frontend/jquery-ui/jquery-ui.css",
                               "~/appfiles/frontend/css/bootstrap-select.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}