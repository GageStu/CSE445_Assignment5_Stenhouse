<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CSE445_Assignment5_Stenhouse.Login" %>
<%@ Register Src="~/LoginWindow.ascx" TagPrefix="uc" TagName="LoginWindow" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style>
        body{font-family:Arial;margin:40px;}
        .box{border:1px solid #aaa;padding:20px;max-width:350px;margin:auto;background:#f9f9f9;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="box">
            <h2>Sign In</h2>
            <uc:LoginWindow ID="Login1" runat="server" />
            <br />
            <asp:HyperLink ID="lnkHome" runat="server" NavigateUrl="~/Default.aspx" Text="Back to Home" />
        </div>
    </form>
</body>
</html>