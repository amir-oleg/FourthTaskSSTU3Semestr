<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ClientSideWebForms.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Button ID="btn_GetAllCustomers" runat="server" OnClick="btn_GetAllCustomers_Click" Text="Get all customers" />
        <asp:GridView ID="grid_Customers" runat="server">
        </asp:GridView>
        <asp:Button ID="btn_ClearGridCustomer" runat="server" OnClick="btn_ClearGridCustomer_Click" Text="Clear table customers" />
        <p>
            <asp:TextBox ID="txtbox_customerId" runat="server"></asp:TextBox>
            <asp:Button ID="btn_GetOrdersById" runat="server" OnClick="btn_GetOrdersById_Click" Text="Get orders by customer id" />
        </p>
        <asp:GridView ID="grid_Orders" runat="server">
        </asp:GridView>
        <asp:Button ID="btn_ClearGridOrders" runat="server" OnClick="btn_ClearGridOrders_Click" Text="Clear table orders" />
    </form>
</body>
</html>
