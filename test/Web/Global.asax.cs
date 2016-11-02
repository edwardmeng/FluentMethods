using System;
using System.Web.Routing;

namespace FluentMethods.WebApp.net45
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.MapPageRoute("GetParameter", "GetParameter/{value}", "~/GetParameter.aspx", false, new RouteValueDictionary { { "value", string.Empty } });
            RouteTable.Routes.MapPageRoute("GetRequiredParameter", "GetRequiredParameter/{value}", "~/GetRequiredParameter.aspx", false,
                new RouteValueDictionary {{"value", string.Empty}});
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}