using System;
using System.Collections.Generic;
using System.Web.UI;

namespace CSE445_Assignment5_Stenhouse
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) PopulateServiceDirectory();

            // Show welcome / logout only when logged in
            if (Session["Username"] != null)
            {
                pnlWelcome.Visible = true;
                lblUser.Text = $"{Session["Username"]} ({Session["Role"]})";
                btnLogout.Visible = true;
            }
            else
            {
                pnlWelcome.Visible = false;
                btnLogout.Visible = false;
            }
        }

        protected void btnTriggerError_Click(object sender, EventArgs e)
        {
            // Deliberately throw an exception to demo Global.asax logging
            throw new Exception("Demo error triggered from Default.aspx.");
        }

        private void PopulateServiceDirectory()
        {
            var list = new List<ServiceEntry>
            {
                new ServiceEntry {
                    Provider = "Stenhouse",
                    ServiceName = "ComputeSHA256(string) → string",
                    Description = "SHA-256 hash (hex).",
                    Resources = "CryptoUtils DLL",
                    TryItLink = "Default.aspx#hash"
                },
                new ServiceEntry {
                    Provider = "Stenhouse",
                    ServiceName = "Error Logging Demo",
                    Description = "Trigger an error to log via Global.asax.",
                    Resources = "Global.asax + App_Data/ErrorLog.txt",
                    TryItLink = "Default.aspx#trigger"
                },
                new ServiceEntry {
                    Provider = "Stenhouse",
                    ServiceName = "Login Navigation",
                    Description = "Navigate to Member or Staff page after login.",
                    Resources = "Default.aspx Navigation Buttons",
                    TryItLink = "Default.aspx#navigation"
                },
                new ServiceEntry {
                    Provider = "Stenhouse",
                    ServiceName = "LoginWindow UserControl",
                    Description = "Reusable login form.",
                    Resources = "LoginWindow.ascx",
                    TryItLink = "~/Login.aspx"
                }
            };
            gvDirectory.DataSource = list;
            gvDirectory.DataBind();
        }

        private class ServiceEntry
        {
            public string Provider { get; set; }
            public string ServiceName { get; set; }
            public string Description { get; set; }
            public string Resources { get; set; }
            public string TryItLink { get; set; }
        }

        protected void btnHash_Click(object sender, EventArgs e)
        {
            string s = txtInput.Text.Trim();
            lblHashResult.Text = string.IsNullOrEmpty(s)
                ? "Enter text."
                : "SHA-256: " + CryptoUtils.ComputeSHA256(s);
        }

        // ---------- NAVIGATION ----------
        protected void btnMember_Click(object sender, EventArgs e)
        {
            // Always go to Member.aspx – it will redirect to Login if needed
            Response.Redirect("~/Member.aspx");
        }

        protected void btnStaff_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Staff.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Default.aspx");
        }
    

        protected void btnStoreFile_Click(object sender, EventArgs e)
        {
            string input = txtFileUrl.Text.Trim();
            if (string.IsNullOrEmpty(input))
            {
                lblFileUrlResult.Text = "Enter a valid URL.";
                return;
            }

            try
            {
                // Call the StorageService
                StorageService service = new StorageService();
                string storedUrl = service.StoreFile(input);

                lblFileUrlResult.Text = storedUrl.StartsWith("Error:")
                    ? storedUrl
                    : "File stored successfully! Access it at: " + Request.Url.GetLeftPart(UriPartial.Authority) + storedUrl;
            }
            catch (Exception ex)
            {
                lblFileUrlResult.Text = "Error: " + ex.Message;
            }
        }
    }
}