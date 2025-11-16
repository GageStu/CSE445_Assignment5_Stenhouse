using System;
using System.Web.UI;

namespace CSE445_Assignment5_Stenhouse
{
    public partial class Member : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"]?.ToString() != "Member")
            {
                // Build ReturnUrl so login sends them back here
                string returnUrl = "~/Member.aspx";
                Response.Redirect("~/Login.aspx?ReturnUrl=" + Server.UrlEncode(returnUrl));
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Default.aspx");
        }
    }
}