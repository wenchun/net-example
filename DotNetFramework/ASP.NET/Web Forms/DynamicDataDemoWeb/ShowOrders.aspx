<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowOrders.aspx.cs" Inherits="ShowOrders" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AllowSorting="True" CellPadding="4" 
        DataKeyNames="OrderID" DataSourceID="EntityDataSource1" ForeColor="#333333" 
        GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ButtonType="Button" CancelText="取消" DeleteText="刪除" 
                EditText="編輯" InsertText="插入" NewText="新增" SelectText="選取" 
                ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" 
                UpdateText="更新">
            <ItemStyle Wrap="False" />
            </asp:CommandField>
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <EmptyDataTemplate>
            <asp:Label ID="Label1" runat="server" Text="查無資料。"></asp:Label>
        </EmptyDataTemplate>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <asp:EntityDataSource ID="EntityDataSource1" runat="server" 
        ConnectionString="name=NorthwindEntities" 
        DefaultContainerName="NorthwindEntities" EnableDelete="True" 
        EnableInsert="True" EnableUpdate="True" 
        EntitySetName="Orders">
    </asp:EntityDataSource>
    </form>
</body>
</html>
