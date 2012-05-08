<%@ Page language="c#" Codebehind="ListBoxDemo.aspx.cs" AutoEventWireup="false" Inherits="AspNetDemo.ListBoundControls.ListBoxDemo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListBoxDemo</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="新細明體">
				<P>
					<asp:Label id="Label1" runat="server" ForeColor="Blue" Font-Size="Large">ListBox Demo</asp:Label></P>
				<P>
					<asp:ListBox id="ListBox1" runat="server" Width="176px" Height="152px"></asp:ListBox></P>
				<P>
					<asp:Button id="Button1" runat="server" Text="Button"></asp:Button></P>
				<P>
					<asp:CheckBox id="chkMultipleSelection" runat="server" Text="啟用多選" AutoPostBack="True"></asp:CheckBox></P>
			</FONT>
		</form>
	</body>
</HTML>
