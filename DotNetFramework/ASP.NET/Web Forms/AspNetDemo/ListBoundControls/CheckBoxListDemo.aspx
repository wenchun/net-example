<%@ Page language="c#" Codebehind="CheckBoxListDemo.aspx.cs" AutoEventWireup="false" Inherits="AspNetDemo.ListBoundControls.CheckBoxListDemo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CheckBoxListDemo</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="Label4" runat="server" ForeColor="Blue" Font-Size="Large" DESIGNTIMEDRAGDROP="30">CheckBoxList Demo</asp:Label>
			<asp:CheckBoxList id="CheckBoxList1" runat="server" RepeatLayout="Flow"></asp:CheckBoxList>
			<P>
				<asp:Button id="Button1" runat="server" Text="Button"></asp:Button></P>
			<FONT face="·s²Ó©úÅé">
				<P>
					<asp:Label id="Label1" runat="server">RepeatColumns: </asp:Label>
					<asp:TextBox id="txtRepeatColumns" runat="server">0</asp:TextBox></P>
				<P>
					<asp:Label id="Label2" runat="server">RepeatDirection: </asp:Label>
					<asp:RadioButton id="rdoRepeatVertical" runat="server" Text="Vertical" GroupName="RepeatDiection"></asp:RadioButton>
					<asp:RadioButton id="rdoRepeatHorizontal" runat="server" Text="Horizontal" GroupName="RepeatDiection"></asp:RadioButton></P>
				<P>
					<asp:Label id="Label3" runat="server">RepeatLayout: </asp:Label>
					<asp:RadioButton id="rdoTableLayout" runat="server" Text="Table" GroupName="RepeatLayout"></asp:RadioButton>
					<asp:RadioButton id="rdoFlowLayout" runat="server" Text="Flow" GroupName="RepeatLayout"></asp:RadioButton></P>
			</FONT>
		</form>
	</body>
</HTML>
