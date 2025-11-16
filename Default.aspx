<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CSE445_Assignment5_Stenhouse.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CSE445 Assignment 5 – Service Demo</title>

    <style>
        body {
            font-family: Arial;
            margin: 20px;
            background: #f7f9fc;
        }

        .section {
            background: white;
            padding: 20px;
            margin-bottom: 25px;
            border-radius: 8px;
            box-shadow: 0 2px 6px rgba(0,0,0,0.1);
        }

        h2, h3 {
            color: #2a4d8f;
        }

        ul li {
            margin-bottom: 5px;
        }

        .service-table th {
            background: #2a4d8f;
            color: white;
        }

        table, th, td {
            border: 1px solid #ccc;
            border-collapse: collapse;
            padding: 8px;
        }

        .btn {
            margin: 5px;
            padding: 10px 16px;
            background: #2a4d8f;
            color: white;
            border: none;
            border-radius: 6px;
            cursor: pointer;
        }

        .btn:hover {
            background: #3c6ddf;
        }

        .input-box {
            width: 400px;
            padding: 6px;
        }

        .result-label {
            margin-top: 5px;
            font-weight: bold;
            display: block;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">

        <div class="section">

            <!-- PROGRAM DESCRIPTION -->
            <h2>CSE445 Assignment 5 – Service-Oriented Web Application</h2>

            <p>This service-oriented web application demonstrates a modular, multi-layer architecture with the following implemented and upcoming features:</p>

            <h3>Current Features</h3>
            <ul>
                <li>🔐 <strong>Login System</strong> – Member and Staff roles with protected pages.</li>
                <li>🔑 <strong>SHA-256 Hashing Service</strong> – Uses CryptoUtils DLL for secure hashing.</li>
                <li>📁 <strong>Storage Service</strong> – Downloads a file from a URL, stores it on the server, returns a link.</li>
                <li>⚠️ <strong>Global.asax Error Logging</strong> – Logs unhandled exceptions into <code>~/App_Data/ErrorLog.txt</code>.</li>
                <li>👀 <strong>Staff Error Log Viewer</strong> – Staff can view logs from Staff.aspx.</li>
            </ul>

            <h3>Upcoming Features (Assignment 6)</h3>
            <ul>
                <li>📂 <strong>Account-based File Storage</strong> – Personalized directories and XML metadata for each user.</li>
                <li>🖼️ <strong>Image Editing Service</strong> – Crop, resize, rotate, and convert images.</li>
                <li>🏷️ <strong>Photo Labeling and Description Service</strong> – Users can tag and describe each stored image.</li>
                <li>📄 <strong>XML Metadata Management</strong> – Creates and maintains per-user XML metadata databases.</li>
            </ul>

            <h3>Available Test Accounts</h3>
            <ul>
                <li><strong>Staff:</strong> TA / Cse445!</li>
                <li><strong>Member:</strong> member / password123</li>
            </ul>

            <h3>Test Cases</h3>
            <table>
                <tr><th>Action</th><th>Input</th><th>Expected Result</th></tr>
                <tr><td>Staff login</td><td>TA / Cse445!</td><td>Redirect to Staff.aspx</td></tr>
                <tr><td>Member login</td><td>member / password123</td><td>Redirect to Member.aspx</td></tr>
                <tr><td>SHA-256 hash</td><td>"hello"</td><td>2cf24dba5fb0a30e26e83b2ac5b9e29e1b161e5c1fa7425e73043362938b9824</td></tr>
                <tr><td>Store file</td><td>Valid URL</td><td>Returns URL to stored file</td></tr>
                <tr><td>Trigger error</td><td>Click button</td><td>Error logged in ~/App_Data/ErrorLog.txt</td></tr>
            </table>

        </div>

        <!-- SERVICE DIRECTORY -->
        <div class="section">
            <h3>Service Directory</h3>
            <asp:GridView ID="gvDirectory" runat="server" AutoGenerateColumns="False" CssClass="service-table">
                <Columns>
                    <asp:BoundField DataField="Provider" HeaderText="Provider" />
                    <asp:BoundField DataField="Component" HeaderText="Component Name" />
                    <asp:BoundField DataField="Type" HeaderText="Page/Type" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:BoundField DataField="Resources" HeaderText="Resources & Usage" />
                </Columns>
            </asp:GridView>
        </div>

        <!-- SHA-256 DEMO -->
        <div class="section">
            <h3>SHA-256 Demo</h3>
            Enter text:
            <asp:TextBox ID="txtInput" runat="server" />
            <asp:Button ID="btnHash" runat="server" Text="Hash" OnClick="btnHash_Click" CssClass="btn" />
            <asp:Label ID="lblHashResult" runat="server" ForeColor="Blue" CssClass="result-label" />
        </div>

        <!-- STORAGE SERVICE DEMO -->
        <div class="section">
            <h3>Storage Service Demo</h3>
            <asp:Label ID="Label_ExampleInput" runat="server" Text="Input link: https://upload.wikimedia.org/wikipedia/commons/4/47/PNG_transparency_demonstration_1.png" ForeColor="Gray" Font-Size="Small" />
            <br /> <br />
            Enter file URL:
            <asp:TextBox ID="txtFileUrl" runat="server" CssClass="input-box" />
            <asp:Button ID="btnStoreFile" runat="server" Text="Store File" OnClick="btnStoreFile_Click" CssClass="btn" />
            <asp:Label ID="lblFileUrlResult" runat="server" ForeColor="Green" CssClass="result-label" />
        </div>

        <!-- ERROR LOGGING DEMO -->
        <div class="section">
            <h3>Global.asax Error Logging Demo</h3>
            <p>Click the button below to trigger a test exception.</p>
            <asp:Button ID="btnTriggerError" runat="server" Text="Trigger Error" OnClick="btnTriggerError_Click" CssClass="btn" />
        </div>

        <!-- NAVIGATION -->
        <div class="section">
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
