<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseForm.aspx.cs" MasterPageFile="~/Site.Master" Inherits="StayBeautifulSMS.PurchaseForm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Purchase"></asp:Label>
        </div>
        <br />
        <br />

        <div>
            <asp:Label ID="Label2" runat="server" Text="Customer"></asp:Label>
            <br />
            <asp:DropDownList ID="customerDDL" runat="server" DataSourceID="SqlDataSource1" DataTextField="customer_name" DataValueField="customer_id"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT [customer_id], [customer_name] FROM [Customer]"></asp:SqlDataSource>
        </div>
        <br />
        <br />
        <div>
            <asp:Label ID="Label4" runat="server" Text="Item"></asp:Label>
            <br />
            <asp:DropDownList ID="itemDDL" runat="server" DataSourceID="SqlDataSource2" DataTextField="item_name" DataValueField="item_id"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT [item_id], [item_name] FROM [Items]"></asp:SqlDataSource>
        </div>
        <br />
        <br />
        <div>
            <asp:Label ID="Label3" runat="server" Text="Quantity"></asp:Label>
            <br />
            <asp:TextBox ID="txQuantity" runat="server"></asp:TextBox>
        </div>
        <br />
        <br />
        <div>
            <asp:Button ID="btnItemAdd" runat="server" Text="Add Item" OnClick="btnItemAdd_Click" />
        </div>
        <br />
        <br />
        <div>
            <asp:GridView ID="purchaseItemGridView" runat="server"></asp:GridView>
        </div>
        <br />
        <br />
        <div>
            <asp:Button ID="btnPurchase" runat="server" Text="Purchase" OnClick="btnPurchase_Click" />
        </div>
    </div>
</asp:Content>
