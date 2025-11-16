using System;
using System.Diagnostics;
using System.IO;

namespace CSE445_Assignment5_Stenhouse
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Trace.WriteLine("Application_Start at " + DateTime.UtcNow.ToString("o"));
            Application["AppStartTime"] = DateTime.UtcNow;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            // Track session start time
            Session["StartedAt"] = DateTime.UtcNow;
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            Trace.WriteLine("Application_Error: " + (ex?.ToString() ?? "null"));

            // log to a file
            try
            {
                string logFile = Server.MapPath("~/App_Data/ErrorLog.txt");
                File.AppendAllText(logFile, DateTime.UtcNow + " - " + (ex?.ToString() ?? "null") + Environment.NewLine);
            }
            catch
            {
                // ignore file write errors
            }
        }
    }
}
