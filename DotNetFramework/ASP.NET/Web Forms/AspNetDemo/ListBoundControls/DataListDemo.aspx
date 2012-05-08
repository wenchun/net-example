<%@ Page language="c#" Codebehind="DataListDemo.aspx.cs" AutoEventWireup="false" Inherits="AspNetDemo.ListBoundControls.DataListDemo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DataListDemo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<P><asp:label id="Label1" runat="server" Font-Size="Large" ForeColor="Blue">DataList Demo</asp:label></P>
			<P><asp:label id="lblStatus" runat="server" ForeColor="Red" Font-Bold="True">���A����</asp:label></P>
			<p></p>
			<asp:datalist id="DataList1" runat="server">
				<HeaderTemplate>
					<table>
						<tr>
							<td><b>�\��s</b></td>
							<td><b>�Ȥ�s��</b></td>
							<td><b>���q�W��</b></td>
							<td><b>�p���H</b></td>
						</tr>
				</HeaderTemplate>
				<SelectedItemTemplate>
					<TR style="BACKGROUND-COLOR: yellow">
						<TD>
							<asp:Button id=Button2 Runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CustomerID") %>' CommandName="select" Text="���"></asp:Button>
							<asp:Button id="Button1" Runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CustomerID") %>' CommandName="edit" Text="�ק�"></asp:Button>
						</TD>
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
						<TD>
							<asp:Button id=btnSelect Runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CustomerID") %>' CommandName="select" Text="���"></asp:Button>
							<asp:Button id="btnEdit" Runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CustomerID") %>' CommandName="edit" Text="�ק�"></asp:Button>
						</TD>
						<TD><%# DataBinder.Eval(Container.DataItem, "CustomerID") %></TD>
						<TD><%# DataBinder.Eval(Container.DataItem, "CompanyName") %></TD>
						<TD><%# DataBinder.Eval(Container.DataItem, "ContactName") %></TD>
					</TR>
				</ItemTemplate>
				<EditItemTemplate>
					<tr style="BACKGROUND-COLOR: #efefef">
						<TD>
							<asp:Button id="btnSave" runat="server" CommandName="save" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CustomerID") %>' Text="�x�s">
							</asp:Button>
							<asp:Button id="btnCancel" runat="server" CommandName="cancel" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CustomerID") %>' Text="����">
							</asp:Button>
						</TD>
						<td>
							<asp:TextBox id="txtCustimerID" runat="server"></asp:TextBox></td>
						<td>
							<asp:TextBox id="txtCompanyName" runat="server"></asp:TextBox></td>
						<td>
							<asp:TextBox id="txtContactName" runat="server"></asp:TextBox></td>
					</tr>
				</EditItemTemplate>
			</asp:datalist></form>
	</body>
</HTML>
