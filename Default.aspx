<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CSE445_Assignment5_Stenhouse.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CSE445 Assignment 5 – Service Demo</title>
    <style>
        body { font-family: Arial; margin: 20px; }
        table, th, td { border: 1px solid #ccc; border-collapse: collapse; padding: 8px; }
        th { background: #f0f0f0; }
        .section { margin: 20px 0; }
        .btn { margin: 5px; padding: 8px 12px; }
        .input-box { width: 400px; }
        .result-label { font-weight: bold; margin-top: 5px; display: block; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="section">

            <!-- PROGRAM DESCRIPTION -->
            <h2>CSE445 Assignment 5 – Service-Oriented Web Application</h2>
            <p>This web application demonstrates a multi-layer architecture with the following features:</p>
            <ul>
                <li>SHA-256 hashing of input text via <strong>CryptoUtils DLL</strong>.</li>
                <li>Storage Service: download a file from a URL and store it on the server, returning a URL to access it.</li>
                <li>Login system with <em>Member</em> and <em>Staff</em> roles and protected pages.</li>
                <li>Error logging via <strong>Global.asax</strong>, demonstrating <em>Application_Error</em>.</li>
                <li>Error logs visible via <em> Staff</em> roles page, click View Error Logs.</li>
            </ul>

            <h3>Available Test Accounts</h3>
            <ul>
                <li><strong>Staff:</strong> TA / Cse445!</li>
                <li><strong>Member:</strong> member / password123</li>
            </ul>

            <!-- TEST CASES -->
            <h3>Test Cases</h3>
            <table>
                <tr><th>Action</th><th>Input</th><th>Expected Result</th></tr>
                <tr><td>Staff login</td><td>TA / Cse445!</td><td>Redirect to Staff.aspx</td></tr>
                <tr><td>Member login</td><td>member / password123</td><td>Redirect to Member.aspx</td></tr>
                <tr><td>SHA-256 hash</td><td>"hello"</td><td>2cf24dba5fb0a30e26e83b2ac5b9e29e1b161e5c1fa7425e73043362938b9824</td></tr>
                <tr><td>Store file</td><td>https://upload.wikimedia.org/wikipedia/commons/4/47/PNG_transparency_demonstration_1.png</td><td>URL returned for stored file on server</td></tr>
                <tr><td>Trigger error</td><td>Click button</td><td>Error logged in ~/App_Data/ErrorLog.txt</td></tr>
            </table>

            <hr />

            <!-- SERVICE DIRECTORY -->
            <h3>Service Directory</h3>
            <asp:GridView ID="gvDirectory" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Provider" HeaderText="Provider" />
                    <asp:BoundField DataField="ServiceName" HeaderText="Service Name" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:BoundField DataField="Resources" HeaderText="Resources" />
                </Columns>
            </asp:GridView>

            <hr />

            <!-- CRYPTO DEMO -->
            <h3>SHA-256 Demo</h3>
            Enter text: <asp:TextBox ID="txtInput" runat="server" />
            <asp:Button ID="btnHash" runat="server" Text="Hash" OnClick="btnHash_Click" CssClass="btn" />
            <asp:Label ID="lblHashResult" runat="server" ForeColor="Blue" CssClass="result-label" />

            <hr />

            <!-- STORAGE SERVICE DEMO -->
            <h3>Storage Service Demo</h3>
            Enter file URL: <asp:TextBox ID="txtFileUrl" runat="server" CssClass="input-box" />
            <asp:Button ID="btnStoreFile" runat="server" Text="Store File" OnClick="btnStoreFile_Click" CssClass="btn" />
            <asp:Label ID="lblFileUrlResult" runat="server" ForeColor="Green" CssClass="result-label" />

            <hr />

            <!-- GLOBAL.ASAX ERROR LOG DEMO -->
            <h3>Global.asax Error Logging Demo</h3>
            <p>Click the button below to deliberately trigger an exception. The error will be logged to <code>~/App_Data/ErrorLog.txt</code>.</p>
            <asp:Button ID="btnTriggerError" runat="server" Text="Trigger Error" OnClick="btnTriggerError_Click" CssClass="btn" />

            <hr />

            <!-- NAVIGATION -->
            <h3>Navigation</h3>
            <asp:Button ID="btnMember" runat="server" Text="Member Page" OnClick="btnMember_Click" CssClass="btn" />
            <asp:Button ID="btnStaff" runat="server" Text="Staff Page" OnClick="btnStaff_Click" CssClass="btn" />
            <asp:Button ID="btnLogout" runat="server" Text="Logout" Visible="false" OnClick="btnLogout_Click" CssClass="btn" />
            <asp:Panel ID="pnlWelcome" runat="server" Visible="false" style="margin-top:15px;">
                <strong>Welcome, <asp:Label ID="lblUser" runat="server" /></strong>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
