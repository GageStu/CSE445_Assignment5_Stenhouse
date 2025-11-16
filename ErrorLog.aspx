<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorLog.aspx.cs" Inherits="CSE445_Assignment5_Stenhouse.ErrorLog" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Error Log Viewer (Staff Only)</title>
    <style>
        body { font-family: Arial; margin: 20px; }
        pre {
            border: 1px solid #ccc;
            padding: 15px;
            background: #fafafa;
            white-space: pre-wrap;
            max-height: 600px;
            overflow-y: scroll;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Error Log Viewer</h2>
        <p>This page is restricted to staff only.</p>

        <asp:Button ID="btnBack" runat="server" Text="Back to Staff Page"
            PostBackUrl="~/Staff.aspx" />

        <br /><br />

        <asp:Literal ID="litLog" runat="server" />

    </form>
</body>
</html>
