using System;
using System.Web;
using System.Web.UI;

namespace CSE445_Assignment5_Stenhouse
{
    public partial class LoginWindow : UserControl
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            // Hard coded accounts for loggin/testing (will be moved to XML for assignment 6 requirements
            if (user == "TA" && pass == "Cse445!")
            {
                Session["Username"] = "TA";
                Session["Role"] = "Staff";
                RedirectAfterLogin();
                return;
            }
            if (user == "member" && pass == "password123")
            {
                Session["Username"] = "member";
                Session["Role"] = "Member";
                RedirectAfterLogin();
                return;
            }

            lblMessage.Text = "Invalid credentials.";
        }

        private void RedirectAfterLogin()
        {
            string returnUrl = Request.QueryString["ReturnUrl"];
            if (string.IsNullOrEmpty(returnUrl) || !returnUrl.StartsWith("~/"))
                returnUrl = "~/Default.aspx";

            Response.Redirect(returnUrl);
        }
    }
}