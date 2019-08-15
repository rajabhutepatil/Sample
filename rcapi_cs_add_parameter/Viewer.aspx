<%@ Page language="c#" Codebehind="Viewer.aspx.cs" AutoEventWireup="false" Inherits="rcapi_cs_add_parameter.Viewer" %>
<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=11.5.3300.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Viewer</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P>
				<asp:Button id="CloseButton" runat="server" Text="Close and Cleanup"></asp:Button></P>
			<P>
				<CR:CrystalReportViewer id="boCrystalReportViewer" runat="server" AutoDataBind="true"></CR:CrystalReportViewer></P>
		</form>
	</body>
</HTML>
