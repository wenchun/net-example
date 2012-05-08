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
			<%-- Repeater 只不過是用來重複一段 HTML 樣板的資料繫結控制項 --%>
			<asp:Repeater id="Repeater1" runat="server">
				<HeaderTemplate>
					<%-- 用來顯示標題的 HTML 樣板（只顯示一次）--%>
					<table>
						<tr>
							<td><b>功能鈕</b></td>
							<td><b>客戶編號</b></td>
							<td><b>公司名稱</b></td>
							<td><b>聯絡人</b></td>
							<td><b>聯絡人職稱</b></td>
						</tr>
				</HeaderTemplate>
				<ItemTemplate>
					<%-- 用來顯示每一筆記錄的 HTML 樣板 --%>
					<tr style="background-color:#efefef">
						<td>
							<asp:Button ID="Button1" Text="選取" CommandName="select" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CustomerID") %>' Runat="server">
							</asp:Button></td>
						<td><%# DataBinder.Eval(Container.DataItem, "CustomerID") %></td>
						<td><%# DataBinder.Eval(Container.DataItem, "CompanyName") %></td>
						<td><%# DataBinder.Eval(Container.DataItem, "ContactName") %></td>
						<td><%# DataBinder.Eval(Container.DataItem, "ContactTitle") %></td>
					</tr>
				</ItemTemplate>
				<FooterTemplate>
					<%-- 用來顯示結尾的 HTML 樣板（只顯示一次）--%>
					</table>
				</FooterTemplate>
			</asp:Repeater>
		</form>
	</body>
</HTML>
