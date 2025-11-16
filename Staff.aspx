<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="CSE445_Assignment5_Stenhouse.Staff" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Staff Area</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding:20px; font-family:Arial;">
            <h2>Staff Page</h2>
            <p>This is a protected staff-only page.</p>
            <p><strong>Logged in as: <%= Session["Username"] %> (Staff)</strong></p>
            <p><em>Test Account: TA / Cse445!</em></p>
            <br />
            <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
            <asp:Button ID="btnHome" runat="server" Text="Back to Home" PostBackUrl="~/Default.aspx" />
            <asp:Button ID="btnLogs" runat="server" Text="View Error Logs" PostBackUrl="~/ErrorLog.aspx" />

        </div>
    </form>
</body>
</html>