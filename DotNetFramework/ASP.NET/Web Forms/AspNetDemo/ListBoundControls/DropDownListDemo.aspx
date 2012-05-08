<%@ Page language="c#" Codebehind="DropDownListDemo.aspx.cs" AutoEventWireup="false" Inherits="AspNetDemo.ListBoundControls.DropDownListDemo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DropDownListDemo</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P>
				<asp:Label id="Label1" runat="server" DESIGNTIMEDRAGDROP="44" ForeColor="Blue" Font-Size="Large">DropDownList Demo</asp:Label></P>
			<P>
				<asp:DropDownList id="ddlCustomers" runat="server"></asp:DropDownList>
				<asp:Button id="btnGetOrders" runat="server" Text="取得訂單資料"></asp:Button></P>
			<P>
				<asp:DataGrid id="DataGrid1" runat="server"></asp:DataGrid></P>
		</form>
	</body>
</HTML>
