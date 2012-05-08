<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopupMenu.aspx.cs" Inherits="PopupMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="StyleSheet.css" />   
    <script src='Scripts/jquery.js' type='text/javascript'></script>
    
    <script type="text/javascript" language="javascript">
      $(document).ready(function() {
        $("#menu").hide();
    
        $("#open").click(function(e) {
          $("#menu").show();
          return false;
        })
      });  
    </script>
</head>
<body>
    <form id="form1" runat="server">    
    <a id="open" href="#">控制面板</a>
      <ul id="menu">
         <li><a href="#1">控制面板首頁</a></li>  
         <li><a href="#2">編輯個人資料</a></li>  
         <li><a href="#3">個人空間管理</a></li>  
      </ul>
    </form>
</body>
</html>
