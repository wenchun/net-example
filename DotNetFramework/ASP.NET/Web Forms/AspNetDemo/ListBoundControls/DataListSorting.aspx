<%@ Page language="c#" Codebehind="DataListSorting.aspx.cs" AutoEventWireup="false" Inherits="Demo2310CS.Mod09.DataListSorting" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DataListSorting</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="新細明體">
				<asp:DataList id="DataList1" style="Z-INDEX: 101; LEFT: 24px; POSITION: absolute; TOP: 16px" runat="server">
					<HeaderTemplate>
						<table>
							<tr>
								<td><b>客戶編號</b></td>
								<td><b>公司名稱</b></td>
								<td>
									<asp:LinkButton id="Button3" Runat="server" CommandName="sort" CommandArgument="ContactName" Text="聯絡人"></asp:LinkButton></td>
							</tr>
					</HeaderTemplate>
					<SelectedItemTemplate>
						<TR style="BACKGROUND-COLOR: yellow">
							<TD><%# DataBinder.Eval(Container.DataItem, "CustomerID") %></TD>
							<TD><%# DataBinder.Eval(Container.DataItem, "CompanyName") %></TD>
							<TD><%# DataBinder.Eval(Container.DataItem, "ContactName") %></TD>
						</TR>
					</SelectedItemTemplate>
					<FooterTemplate>
						</table>
					</FooterTemplate>
					<ItemTemplate>
						<TR style="BACKGROUND-COLOR: #efefef">
							<TD><%# DataBinder.Eval(Container.DataItem, "CustomerID") %></TD>
							<TD><%# DataBinder.Eval(Container.DataItem, "CompanyName") %></TD>
							<TD><%# DataBinder.Eval(Container.DataItem, "ContactName") %></TD>
						</TR>
					</ItemTemplate>
					<EditItemTemplate>
						<tr style="BACKGROUND-COLOR: #efefef">
							<td>
								<asp:TextBox id="txtCustimerID" runat="server"></asp:TextBox></td>
							<td>
								<asp:TextBox id="txtCompanyName" runat="server"></asp:TextBox></td>
							<td>
								<asp:TextBox id="txtContactName" runat="server"></asp:TextBox></td>
						</tr>
					</EditItemTemplate>
				</asp:DataList></FONT>
		</form>
	</body>
</HTML>
