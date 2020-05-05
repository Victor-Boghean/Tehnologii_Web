using System.Web.Optimization;

namespace eUseControl.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bootstrap-css
            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include("~/Content/bootstrap.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new ScriptBundle("~/bundles/bootsrap/js").Include("~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include("~/assets/js/function.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery/js").Include("~/Scripts/jquery-{version}.js"));

            //stil pentru font
            bundles.Add(new StyleBundle("~/bundles/font-awesome/css").Include("~/Content/font-awesome.min.css", new CssRewriteUrlTransform()));

            //stilul principal
            bundles.Add(new StyleBundle("~/bundles/assets/css/style").Include("~/assets/css/style.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/css/ProductStyle").Include("~/assets/css/ProductStyle.css", new CssRewriteUrlTransform()));

            //stiluri pentru register-form   
            bundles.Add(new StyleBundle("~/bundles/assets/RegisterForm").Include(
                "~/assets/RegisterForm/css/style.css",
                "~/assets/RegisterForm/scss/style.css",
                "~/assets/RegisterForm/fonts/material-icon/css/material-design-iconic-font.min.css",
                "~/assets/RegisterForm/fonts/material-icon/css/material-design-iconic-font.min.css"));

            

            //scripturi pentru validarea formei din partea clientului
            bundles.Add(new ScriptBundle("~/bundles/jqueryval/js").Include(
                "~/Scripts/jquery-{version}.min.js",
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.validate.unobtrusive.min.js")); 
        }
    }
}