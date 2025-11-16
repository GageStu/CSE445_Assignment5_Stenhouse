using System;
using System.Web.UI;

namespace CSE445_Assignment5_Stenhouse
{
    public partial class Staff : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"]?.ToString() != "Staff")
            {
                string returnUrl = "~/Staff.aspx";
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