using System;
using System.Collections.Generic;
using System.Web.UI;

namespace CSE445_Assignment5_Stenhouse
{
    public partial class Default : Page
    {

        // Simple page load on startup to show session persistence
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                PopulateServiceDirectory();

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

        // Error demo for Global.asax (TryIt demo for Global.asax)
        protected void btnTriggerError_Click(object sender, EventArgs e)
        {
            throw new Exception("Demo error triggered from Default.aspx.");
        }

        // Service Directory Table
        private void PopulateServiceDirectory()
        {
            var list = new List<ServiceEntry>
            {
                new ServiceEntry {
                    Provider = "Stenhouse",
                    Component = "SHA-256 Hash Function",
                    Type = "DLL",
                    Description = "Input: string → Output: SHA-256 hash hex string.",
                    Resources = "CryptoUtils.dll – used in btnHash_Click()"
                },

                new ServiceEntry {
                    Provider = "Stenhouse",
                    Component = "StorageService.StoreFile()",
                    Type = "C# Class / ASPX Integration",
                    Description = "Input: File URL → Output: stored file path URL on server.",
                    Resources = "StorageService.cs – used in btnStoreFile_Click()"
                },

                new ServiceEntry {
                    Provider = "Stenhouse",
                    Component = "Login System",
                    Type = "ASPX Page + Code-behind",
                    Description = "Authenticates user and redirects based on role.",
                    Resources = "Login.aspx, Member.aspx, Staff.aspx + session variables"
                },

                new ServiceEntry {
                    Provider = "Stenhouse",
                    Component = "Global Error Logger",
                    Type = "Global.asax",
                    Description = "Logs unhandled exceptions. No inputs.",
                    Resources = "Application_Error() + App_Data/ErrorLog.txt"
                },

                new ServiceEntry {
                    Provider = "Stenhouse",
                    Component = "LoginWindow UserControl",
                    Type = "ASCX Control",
                    Description = "Reusable login UI. Inputs: username/password.",
                    Resources = "LoginWindow.ascx – used on Login.aspx"
                }
            };

            gvDirectory.DataSource = list;
            gvDirectory.DataBind();
        }

        // Data model for service directory
        private class ServiceEntry
        {
            public string Provider { get; set; }
            public string Component { get; set; }
            public string Type { get; set; }
            public string Description { get; set; }
            public string Resources { get; set; }
        }

        // Hashing function demo (for TryIt)
        protected void btnHash_Click(object sender, EventArgs e)
        {
            string s = txtInput.Text.Trim();
            lblHashResult.Text = string.IsNullOrEmpty(s)
                ? "Enter text."
                : "SHA-256: " + CryptoUtils.ComputeSHA256(s);
        }

        // File Storage demo (for TryIt)
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
                StorageService service = new StorageService();
                string storedUrl = service.StoreFile(input);

                lblFileUrlResult.Text = storedUrl.StartsWith("Error:")
                    ? storedUrl
                    : "File stored successfully! Access it at: " +
                      Request.Url.GetLeftPart(UriPartial.Authority) + storedUrl;
            }
            catch (Exception ex)
            {
                lblFileUrlResult.Text = "Error: " + ex.Message;
            }
        }

        // Navigation for member/staff pages (placeholders to show basic function)
        protected void btnMember_Click(object sender, EventArgs e)
        {
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
    }
}
