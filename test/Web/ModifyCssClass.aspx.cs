using System;

namespace FluentMethods.WebApp.net45
{
    public partial class ModifyCssClass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var className = Request.QueryString["class"];
            switch (Request.QueryString["action"])
            {
                case "add":
                    labelValue.AddCssClass(className);
                    textValue.AddCssClass(className);
                    break;
                case "remove":
                    labelValue.RemoveCssClass(className);
                    textValue.RemoveCssClass(className);
                    break;
                case "toggle":
                    labelValue.ToggleCssClass(className);
                    textValue.ToggleCssClass(className);
                    break;
            }
        }
    }
}