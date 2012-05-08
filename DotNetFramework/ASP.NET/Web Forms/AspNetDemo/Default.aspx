<%@ Page language="c#" Codebehind="Default.aspx.cs" AutoEventWireup="false" Inherits="Demo.WebForm1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<FONT face="·s²Ó©úÅé">
				<P>
					<asp:Label id="Label1" runat="server" Font-Size="Medium">Exception Handling</asp:Label></P>
				<P>
					<asp:HyperLink id="HyperLink1" runat="server" NavigateUrl="ErrorHandling/UnhandledException.aspx">Unhandled exception</asp:HyperLink></P>
				<P>
					<asp:HyperLink id="HyperLink2" runat="server" NavigateUrl="ErrorHandling/UsePageErrorEvent.aspx">Handle exception in page's Error event</asp:HyperLink></P>
			</FONT>
		</form>
	</body>
</HTML>
