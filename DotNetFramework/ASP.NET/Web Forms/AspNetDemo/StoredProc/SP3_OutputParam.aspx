<%@ Page language="c#" Codebehind="SP3_OutputParam.aspx.cs" AutoEventWireup="false" Inherits="AspNetDemo.StoredProc.SP3_OutputParam" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SP3_OutputParam</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<P>
				<asp:Label id="Label1" runat="server">客戶編號</asp:Label>
				<asp:TextBox id="txtCustomerID" runat="server">ALFKI</asp:TextBox></P>
			<FONT face="新細明體">
				<P>
					<asp:Button id="btnOutputParam" runat="server" Width="232px" Text="呼叫需要輸出參數的預儲程序"></asp:Button></P>
				<P>
			</FONT>
			<asp:Label id="Label2" runat="server">Label</asp:Label></P>
		</form>
	</body>
</HTML>
