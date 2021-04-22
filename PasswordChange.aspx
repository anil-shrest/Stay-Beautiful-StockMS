<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PasswordChange.aspx.cs" MasterPageFile="~/Site.Master" Inherits="StayBeautifulSMS.PasswordChange" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Password Change"></asp:Label>
    </div>
    <br />
    <br />
    <div>
        <asp:Label ID="Label2" runat="server" Text="Current Password"></asp:Label>
        <br />
        <asp:TextBox ID="txtCurrentPw" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label3" runat="server" Text="New Password"></asp:Label>
        <br />
        <asp:TextBox ID="txtNewPw1" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label4" runat="server" Text="Re-Enter Password"></asp:Label>
        <br />
        <asp:TextBox ID="txtNewPw2" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" />
    </div>
</asp:Content>
