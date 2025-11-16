// Sourced solution to TLS errors/aborts from stack overflow here:
// https://stackoverflow.com/questions/71768631/forcing-net-application-to-use-tls-1-2-or-later

using System;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Services;

namespace CSE445_Assignment5_Stenhouse
{
    [WebService(Namespace = "http://cse445.stenhouse.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class StorageService : WebService
    {
        private string uploadFolder = "~/UploadedFiles/";

        [WebMethod]
        public string StoreFile(string fileUrl)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(fileUrl))
                    throw new ArgumentException("fileUrl cannot be empty.");

                if (!Uri.IsWellFormedUriString(fileUrl, UriKind.Absolute))
                    throw new ArgumentException("Input must be a valid URL.");

                string serverPath = Server.MapPath(uploadFolder);

                if (!Directory.Exists(serverPath))
                    Directory.CreateDirectory(serverPath);

                // Extract original filename from URL
                string baseFileName = Path.GetFileName(fileUrl);

                if (string.IsNullOrEmpty(baseFileName))
                    baseFileName = "file"; // fallback

                string destFileName = baseFileName;
                string destPath = Path.Combine(serverPath, destFileName);

                // Avoid overwriting existing files (like SaveAs example)
                int counter = 1;
                while (File.Exists(destPath))
                {
                    destFileName = $"{Path.GetFileNameWithoutExtension(baseFileName)}_{counter}{Path.GetExtension(baseFileName)}";
                    destPath = Path.Combine(serverPath, destFileName);
                    counter++;
                }

                // Force TLS 1.2 for HTTPS (Was getting repeated errors for Sec protocol without 
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                // Download the file from the URL
                using (WebClient client = new WebClient())
                {
                    client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");
                    client.DownloadFile(fileUrl, destPath);
                }

                // Return the relative URL to the file on the server
                string savedUrl = VirtualPathUtility.ToAbsolute(uploadFolder + destFileName);
                return savedUrl;
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
    }
}
