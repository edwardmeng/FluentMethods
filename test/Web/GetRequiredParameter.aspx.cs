using System;

namespace FluentMethods.WebApp.net45
{
    public partial class GetRequiredParameter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            labelValue.Text = Request.GetRequiredParameter<Guid>("value").ToString();
        }
    }
}