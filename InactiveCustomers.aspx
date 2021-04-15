<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InactiveCustomers.aspx.cs" MasterPageFile="~/Site.Master" Inherits="StayBeautifulSMS.InactiveCustomers" %>

<asp:Content ID="bodyContent" ContentPlaceHolderID="MainContent" runat="server" >
    <div>
        <asp:Label ID="title" class="" runat="server" Text="Inactive Customers"></asp:Label>
    </div>
    <br />
    <br />
    <br />
    <div>
        <asp:GridView ID="inactiveCustomerGrid" runat="server" DataKeyNames="Customer_ID" ></asp:GridView>

</asp:Content>
