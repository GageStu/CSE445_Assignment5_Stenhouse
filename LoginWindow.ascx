<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginWindow.ascx.cs" Inherits="CSE445_Assignment5_Stenhouse.LoginWindow" %>

<asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label><br />
Username: <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox><br /><br />
Password: <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br /><br />
<asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />