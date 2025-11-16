using System;
using System.Web.UI;

namespace CSE445_Assignment5_Stenhouse
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // If already logged in, send them to the page they wanted (or home)
            if (Session["Username"] != null)
            {
                string returnUrl = Request.QueryString["ReturnUrl"];
                Response.Redirect(string.IsNullOrEmpty(returnUrl) ? "~/Default.aspx" : returnUrl);
            }
        }
    }
}