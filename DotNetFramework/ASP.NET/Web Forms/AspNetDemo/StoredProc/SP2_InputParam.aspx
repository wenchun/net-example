<%@ Page language="c#" Codebehind="SP2_InputParam.aspx.cs" AutoEventWireup="false" Inherits="AspNetDemo.StoredProc.SP2_WithParam" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DemoSP2_WithParam</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="�s�ө���">
				<P>
					<asp:Label id="Label1" runat="server">�Ȥ�s��</asp:Label>
					<asp:TextBox id="txtCustomerID" runat="server">ALFKI</asp:TextBox></P>
				<P>
					<asp:Button id="btnInputParam" runat="server" Width="232px" Text="�I�s�ݭn�ǤJ�Ѽƪ��w�x�{��"></asp:Button></P>
			</FONT>
			<P><FONT face="�s�ө���"></P>
			<asp:DataGrid id="DataGrid1" runat="server" Width="376px" Height="232px"></asp:DataGrid></FONT>
		</form>
	</body>
</HTML>
