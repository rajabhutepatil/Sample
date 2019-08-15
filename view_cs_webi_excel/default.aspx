<%@ Page language="c#" Inherits="SimpleWebiXLSViewer._default" CodeFile="default.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>default</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<div id="mainContainer">
			<div id="sampleDescriptionDiv">
				<h1 id="sampleTitle">Web Intelligence Excel View Sample</h1>
				<p id="sampleDescription">This sample illustrates how to display a Web Intelligence
				report using Excel.
				</p>
			</div>
			<!-- Form to capture information necessary to run the sample
		****************************************************** -->
			<form id="sampleForm" runat="server">
				<table class="infoTbl">
					<TR>
						<th colSpan="2">
							Please enter your log on info</th>
					<tr>
						<td>CMS:
						</td>
						<td><asp:textbox id="txtCMSName" runat="server" CssClass="formField"></asp:textbox></td>
					</tr>
					<tr>
						<td>User Name:
						</td>
						<td><asp:textbox id="txtUserName" runat="server" CssClass="formField"></asp:textbox></td>
					</tr>
					<tr>
						<td>Password:
						</td>
						<td><asp:textbox id="txtPassword" runat="server" CssClass="formField" TextMode="Password"></asp:textbox></td>
					</tr>
					<tr>
						<td>Authentication Type:
						</td>
						<td><asp:dropdownlist id="lstAuthType" runat="server" CssClass="formField">
								<asp:ListItem Value="secEnterprise">Enterprise</asp:ListItem>
								<asp:ListItem Value="secLDAP">LDAP</asp:ListItem>
								<asp:ListItem Value="secWinAD">WIN AD</asp:ListItem>
							</asp:dropdownlist></td>
					</tr>
                    <tr>
                        <td>
                            Webi Report Name:</td>
                        <td>
                            <asp:TextBox ID="txtWebiName" runat="server" CssClass="formField"></asp:TextBox></td>
                    </tr>
					<tr>
						<td></td>
						<td><asp:button id="btnSubmit" runat="server" Text="Submit" CssClass="btn" onclick="btnSubmit_Click"></asp:button></td>
					</tr>
				</table>
			</form>
			<div class="infoDiv">
				<table class="infoTbl">
					<TR>
						<th class="tableHeader">
							Notes:</th>
					<tr>
						<td>
							<p>You can view the <A href="readme.txt" target="_blank">Read Me</A> file for 
								instructions on how to install this sample.</p>
							<p>Please visit our <a href="http://devlibrary.businessobjects.com/" target="_blank">online 
									library</a> for up to date SDK help files.</p>
						</td>
					</tr>
				</table>
			</div>
			<div id="copyright">© Business Objects Technical Customer Assurance</div>
		</div>
	</body>
</HTML>
