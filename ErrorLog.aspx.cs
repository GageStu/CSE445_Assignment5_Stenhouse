using System;
using System.IO;
using System.Web.UI;

namespace CSE445_Assignment5_Stenhouse
{
    public partial class ErrorLog : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Staff-only access check
            if (Session["Role"]?.ToString() != "Staff")
            {
                Response.Redirect("~/Login.aspx?ReturnUrl=" + Server.UrlEncode("~/ErrorLog.aspx"));
                return;
            }

            LoadLog();
        }

        private void LoadLog()
        {
            try
            {
                string path = Server.MapPath("~/App_Data/ErrorLog.txt");

                if (!File.Exists(path))
                {
                    litLog.Text = "<pre>No log file exists yet.</pre>";
                    return;
                }

                string contents = File.ReadAllText(path);
                litLog.Text = "<pre>" + Server.HtmlEncode(contents) + "</pre>";
            }
            catch (Exception ex)
            {
                litLog.Text = "<pre>Error reading log: " + Server.HtmlEncode(ex.Message) + "</pre>";
            }
        }
    }
}
