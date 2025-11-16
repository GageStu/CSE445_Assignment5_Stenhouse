using System;
using System.Diagnostics;
using System.IO;

namespace CSE445_Assignment5_Stenhouse
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // Example: log app start to trace for grading/debugging
            Trace.WriteLine("Application_Start at " + DateTime.UtcNow.ToString("o"));

            // Optional: initialize application-wide counters (used to test Global.asax and demo on Default)
            Application["ActiveSessions"] = 0;

            // Optional: store app start time
            Application["AppStartTime"] = DateTime.UtcNow;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            // Track session start time
            Session["StartedAt"] = DateTime.UtcNow;

            // Increment active session counter
            if (Application["ActiveSessions"] != null)
                Application["ActiveSessions"] = (int)Application["ActiveSessions"] + 1;
            else
                Application["ActiveSessions"] = 1;
        }

        protected void Session_End(object sender, EventArgs e)
        {
            // Decrement active session counter
            if (Application["ActiveSessions"] != null)
                Application["ActiveSessions"] = (int)Application["ActiveSessions"] - 1;
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            Trace.WriteLine("Application_Error: " + (ex?.ToString() ?? "null"));

            // Optionally log to a file
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
