<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseBill.aspx.cs" MasterPageFile="~/Site.Master" Inherits="StayBeautifulSMS.PurchaseBill" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server"> 
    <div>
        <asp:Label ID="Label1" runat="server" Text="Purchase ID"></asp:Label>
        <asp:Label ID="lblPID" runat="server"></asp:Label>
    </div>
    <div>
        <asp:Label ID="Label3" runat="server" Text="Purchased Date"></asp:Label>
        <asp:Label ID="lblPD" runat="server"></asp:Label>
    </div>
    <div>
        <asp:Label ID="Label5" runat="server" Text="Customer ID"></asp:Label>
        <asp:Label ID="lblCID" runat="server"></asp:Label>
    </div>
    <div>
        <asp:Label ID="Label7" runat="server" Text="Customer Name"></asp:Label>
        <asp:Label ID="lblCN" runat="server"></asp:Label>
    </div>
    <div>
        <asp:Label ID="Label9" runat="server" Text="Billing By"></asp:Label>
        <asp:Label ID="lblBill" runat="server"></asp:Label>
    </div>
    <div>
        <asp:GridView ID="billGridView" runat="server"></asp:GridView>
    </div>
    <div>
        <asp:Label ID="Label2" runat="server" Text="Amount"></asp:Label>
        <asp:Label ID="lblAmount" runat="server"></asp:Label>
    </div>
    <div>
        <asp:Label ID="Label4" runat="server" Text="Discount"></asp:Label>
        <asp:Label ID="lblDis" runat="server"></asp:Label>
    </div>
    <div>
        <asp:Label ID="Label6" runat="server" Text="Total Amount"></asp:Label>
        <asp:Label ID="lblTotal" runat="server"></asp:Label>
    </div>
</asp:Content>
