<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="CSE445_Assignment5_Stenhouse.Member" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Member Area</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding:20px; font-family:Arial;">
            <h2>Member Page</h2>
            <p>This is a protected page. Only logged-in members can access it.</p>
            <p><strong>Welcome, <%= Session["Username"] %>!</strong></p>
            <p><em>(Placeholder for Assignment 6 features like registration, shopping cart, etc.)</em></p>
            <br />
            <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
            <asp:Button ID="btnHome" runat="server" Text="Back to Home" PostBackUrl="~/Default.aspx" />
        </div>
    </form>
</body>
</html>