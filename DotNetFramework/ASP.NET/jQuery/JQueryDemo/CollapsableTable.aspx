<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src='Scripts/jquery.js' type='text/javascript'></script>
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            var depositOptions = $('#depositOptions');
            depositOptions.hide();

            // "台幣存款業務" 的 click 事件處理常式
            $('#depositLabel').click(function () {
                toggleOptions(depositOptions);
            });

            // "台幣授信業務" 的 click 事件處理常式
            $('#creditLabel').click(function () {
                toggleOptions($('#creditOptions'));
            });

            // "外匯業務" 的 click 事件處理常式
            $('#exchangeLabel').click(function () {
                toggleOptions($('#exchangeOptions'));
            });

        });

        // 將某個選項區塊做上下滑動的狀態切換
        function toggleOptions(aOptions) {
            if (aOptions.is(':visible')) {
                aOptions.slideUp();
            } else {
                aOptions.slideDown();
            }
        }
    
    </script>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 133px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="style1">
            <tr style="background-color: #FFFFCC">
                <td style="text-align: right; vertical-align: top" class="style2">                    
                    <span id="creditLabel" title="選我選我!" style="cursor: pointer">台幣授信業務：</span>
                </td>
                <td>
                    <div id="creditOptions">
                        <input name="Checkbox1" type="checkbox" />1.借貸<br />
                        <input name="Checkbox2" type="checkbox" />2.還款<br />
                    </div>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; vertical-align: top;" class="style2">
                    <span id="depositLabel" title="選我選我!" style="cursor: pointer">台幣存款業務：</span>
                </td>
                <td>
                    <div id="depositOptions">
                        <input name="Checkbox1" type="checkbox" />1.媒體交換自動轉帳<br />
                        <input name="Checkbox2" type="checkbox" />2.支票存款<br />
                        <input name="Checkbox3" type="checkbox" />3.存摺存款<br />
                        <input name="Checkbox4" type="checkbox" />4.存單存款<br />
                        <input name="Checkbox5" type="checkbox" />5.短期票券....<br />
                    </div>
                </td>
            </tr>
            <tr style="background-color: #FFFFCC">
                <td style="text-align: right; vertical-align: top" class="style2">                    
                    <span id="exchangeLabel" title="選我選我!" style="cursor: pointer">外匯業務：</span>
                </td>
                <td>
                    <div id="exchangeOptions">
                        <input name="Checkbox1" type="checkbox" />1.外匯活存<br />
                        <input name="Checkbox2" type="checkbox" />2.優惠查詢<br />
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
