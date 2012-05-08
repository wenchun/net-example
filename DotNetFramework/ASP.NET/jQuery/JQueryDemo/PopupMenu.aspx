<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopupMenu.aspx.cs" Inherits="PopupMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="StyleSheet.css" />   
    <script src='Scripts/jquery.js' type='text/javascript'></script>
    
    <script type="text/javascript" language="javascript">

        var needHide = false;
        
        function hideMenu() 
        {
            if (needHide) {
                $('#menuItems').fadeOut('fast');
            } 
        } //checkHover

        $(document).ready(function() {
            $('#menuBlock').hide();

            $('#imgTest').click(function(e) {
                $('#menuBlock').show();
                // 讓選單秀在滑鼠點擊區域內，以確保選單的 hover 動作正常。
                var x = e.pageX - 2;
                var y = e.pageY - 2;
                $('#menuItems').css({ position: "absolute", marginLeft: 0, marginTop: 0, top: y, left: x });
                $('#menuItems').fadeIn("fast");
            });

            $('#menuItems').hover(function(e) {
                needHide = false;
            },
            function() {
                needHide = true;
                setTimeout("hideMenu()", 400);
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <img id="imgTest" src="Images/test.gif" alt="圖片" />
    <div id="menuBlock">
        <ul id="menuItems" class="PopupMenu">
            <li><a href="http://www.google.com">性格測驗系統</a></li>
            <li><a href="http://www.google.com">IQ 測驗系統</a></li>
        </ul>
    </div>
    </form>
</body>
</html>
