<%@ Page language="c#" Codebehind="SP1_NoParam.aspx.cs" AutoEventWireup="false" Inherits="AspNetDemo.StoredProc.SP1_NoParam" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DemoSP1_Select</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="�s�ө���">
				<P><asp:button id="btnGetRecords" runat="server" Width="272px" Text="�I�s [Ten Most Expensive Products]"></asp:button></P>
				<P>
					<asp:DataGrid id="DataGrid1" runat="server" Width="544px" Height="248px" PageSize="5"></asp:DataGrid><asp:button id="btnGetValue" runat="server" Width="344px" Text="�I�s Stored Procedure ���o�Ĥ@���O�����Ĥ@������"></asp:button></P>
				<P><asp:label id="Label1" runat="server">�Ȥ��Ƶ���:</asp:label><asp:textbox id="TextBox1" runat="server" Width="120px"></asp:textbox></P>
				<P><asp:button id="btnExecuteNonQuery" runat="server" Width="280px" Text="�I�s Stored Procedure �H����@���u�@"></asp:button></P>
				<P>&nbsp;</P>
			</FONT>
			<P>&nbsp;</P>
			<P><FONT face="�s�ө���"></FONT>&nbsp;</P>
		</form>
	</body>
</HTML>
