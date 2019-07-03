<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Request.aspx.cs" Inherits="Paytm_Payment_Gateway.Request" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>PayTm</h3>
            <br />
            <asp:Label>Email</asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <br />
            <asp:Label>Mobile Number</asp:Label>
            <asp:TextBox ID="txtMobileNumber" runat="server"></asp:TextBox>
            <br />
            <asp:Button Text="Pay with PayTm" runat="server" ID="btnPay" OnClick="PaytmPayment" />
        </div>
    </form>
</body>
</html>
