<%@ Page language="c#" Codebehind="UsePageErrorEvent.aspx.cs" AutoEventWireup="false" Inherits="AspNetDemo.UsePageErrorEvent" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>UnhandledException</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<FONT face="新細明體">
				<P>
					<asp:Label id="Label1" runat="server">測試未處理的異常在瀏覽器中顯示的結果。注意：本機和遠端存取的結果不同！</asp:Label></P>
				<P>
					<asp:Button id="Button1" runat="server" Text="Go!" Width="101px" Height="41px" Font-Size="Medium"></asp:Button></P>
			</FONT>
		</form>
	</body>
</HTML>
