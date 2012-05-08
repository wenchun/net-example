<%@ Page language="c#" Codebehind="RepeaterDemo.aspx.cs" AutoEventWireup="false" Inherits="AspNetDemo.ListBoundControls.RepeaterDemo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RepeaterDemo</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="Label1" runat="server" ForeColor="Blue" Font-Size="Large">Repeater Demo</asp:Label>
			<p></p>
			<%-- Repeater �u���L�O�Ψӭ��Ƥ@�q HTML �˪O�����ô����� --%>
			<asp:Repeater id="Repeater1" runat="server">
				<HeaderTemplate>
					<%-- �Ψ���ܼ��D�� HTML �˪O�]�u��ܤ@���^--%>
					<table>
						<tr>
							<td><b>�\��s</b></td>
							<td><b>�Ȥ�s��</b></td>
							<td><b>���q�W��</b></td>
							<td><b>�p���H</b></td>
							<td><b>�p���H¾��</b></td>
						</tr>
				</HeaderTemplate>
				<ItemTemplate>
					<%-- �Ψ���ܨC�@���O���� HTML �˪O --%>
					<tr style="background-color:#efefef">
						<td>
							<asp:Button ID="Button1" Text="���" CommandName="select" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CustomerID") %>' Runat="server">
							</asp:Button></td>
						<td><%# DataBinder.Eval(Container.DataItem, "CustomerID") %></td>
						<td><%# DataBinder.Eval(Container.DataItem, "CompanyName") %></td>
						<td><%# DataBinder.Eval(Container.DataItem, "ContactName") %></td>
						<td><%# DataBinder.Eval(Container.DataItem, "ContactTitle") %></td>
					</tr>
				</ItemTemplate>
				<FooterTemplate>
					<%-- �Ψ���ܵ����� HTML �˪O�]�u��ܤ@���^--%>
					</table>
				</FooterTemplate>
			</asp:Repeater>
		</form>
	</body>
</HTML>
