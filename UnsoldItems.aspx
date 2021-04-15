<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnsoldItems.aspx.cs" MasterPageFile="~/Site.Master" Inherits="StayBeautifulSMS.UnsoldItems" %>

<asp:Content ID="bodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <asp:Label ID="Label1" class="title" runat="server" Text="Unsold Items"></asp:Label>
    </div>
    <br />
    <br />
    <div>
        <asp:GridView ID="unsoldItemsGrid" runat="server" DataKeyNames="Item_ID"></asp:GridView>
    </div>
</asp:Content>
