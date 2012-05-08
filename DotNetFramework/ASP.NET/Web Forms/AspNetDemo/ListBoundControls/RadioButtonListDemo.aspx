<%@ Page language="c#" Codebehind="RadioButtonListDemo.aspx.cs" AutoEventWireup="false" Inherits="AspNetDemo.ListBoundControls.RadioButtonListDemo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RadioButtonListDemo</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="Label1" runat="server" ForeColor="Blue" Font-Size="Large">RadioButtonList Demo</asp:Label>
			<asp:RadioButtonList id="RadioButtonList1" runat="server" RepeatColumns="3"></asp:RadioButtonList>
			<asp:Button id="Button1" runat="server" Text="Button"></asp:Button>
		</form>
	</body>
</HTML>
