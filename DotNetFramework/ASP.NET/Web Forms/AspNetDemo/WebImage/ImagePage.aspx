<%@ Page language="c#" Codebehind="ImagePage.aspx.cs" AutoEventWireup="false" Inherits="AspNetDemo.WebImage.ImagePage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebImageDemo</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<P><FONT face="�s�ө���">�������ܽd�p��ʺA���ͺ����W���Ϥ�</FONT></P>
			<FONT face="�s�ө���">
				<P>
					<asp:RadioButton id="rdoFromFile" runat="server" Text="�q�ɮ׸��J�Ϥ�" GroupName="ImageSrc" Checked="True"></asp:RadioButton>
					<asp:RadioButton id="rdoFromDb" runat="server" Text="��ܸ�Ʈw���Ϥ�" GroupName="ImageSrc"></asp:RadioButton></P>
				<P>
					<asp:Button id="btnOk" runat="server" Text="�T�w"></asp:Button></P>
				<P>
					<asp:Image id="Image1" runat="server" AlternateText="�o�̱N��ܹϤ�"></asp:Image></P>
			</FONT>
		</form>
	</body>
</HTML>
