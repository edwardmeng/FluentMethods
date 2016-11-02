using System;

namespace FluentMethods.WebApp.net45
{
    public partial class GetParameter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            labelValue.Text = Request.GetParameter<Guid>("value").ToString();
        }
    }
}