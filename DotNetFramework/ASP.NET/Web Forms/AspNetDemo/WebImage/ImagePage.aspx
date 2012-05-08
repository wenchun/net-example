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
			<P><FONT face="新細明體">此網頁示範如何動態產生網頁上的圖片</FONT></P>
			<FONT face="新細明體">
				<P>
					<asp:RadioButton id="rdoFromFile" runat="server" Text="從檔案載入圖片" GroupName="ImageSrc" Checked="True"></asp:RadioButton>
					<asp:RadioButton id="rdoFromDb" runat="server" Text="顯示資料庫的圖片" GroupName="ImageSrc"></asp:RadioButton></P>
				<P>
					<asp:Button id="btnOk" runat="server" Text="確定"></asp:Button></P>
				<P>
					<asp:Image id="Image1" runat="server" AlternateText="這裡將顯示圖片"></asp:Image></P>
			</FONT>
		</form>
	</body>
</HTML>
