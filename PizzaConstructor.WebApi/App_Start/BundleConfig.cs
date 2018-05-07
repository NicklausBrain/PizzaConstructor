using System.Web.Optimization;

namespace PizzaConstructor.WebApi
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js",
                "~/Scripts/materialize/materialize.js"));

            bundles.Add(new ScriptBundle("~/bundles/react").Include(
                "~/Scripts/react.js",
                "~/Scripts/react-dom.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/site.css",
                "~/Content/bootstrap.css",
                "~/Content/materialize.css",
                "~/Content/Custom/*.css"));

            bundles.Add(new ScriptBundle("~/scripts/react-components").Include(
                "~/Scripts/ReactComponents/ModaleBox.jsx",
                "~/Scripts/ReactComponents/TemplateForm.jsx",
                "~/Scripts/ReactComponents/Template.jsx",
                "~/Scripts/ReactComponents/TemplateBox.jsx",
                "~/Scripts/ReactComponents/IngredientComponent.jsx",
                "~/Scripts/ReactComponents/TabContentComponent.jsx",                
                "~/Scripts/ReactComponents/TabComponent.jsx",
                "~/Scripts/ReactComponents/PizzaTitleComponent.jsx",
                "~/Scripts/ReactComponents/PizzaImageComponent.jsx",
                "~/Scripts/ReactComponents/PizzaIngredientsComponent.jsx",
                "~/Scripts/ReactComponents/PizzaConstructorComponent.jsx",
                "~/Scripts/ReactComponents/OrderBuilder.jsx",
                "~/Scripts/ReactComponents/PizzaItem.jsx",
                "~/Scripts/ReactComponents/OrdersHistory.jsx",
                "~/Scripts/ReactComponents/AdminBoxOrder.jsx",
                "~/Scripts/ReactComponents/AdminBox.jsx"));

        }
    }
}
