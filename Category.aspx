<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Category.aspx.cs" Inherits="StayBeautifulSMS.Category" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Item Category"></asp:Label>
        </div>
        <br />
        <br />
        <div>
            <asp:Label runat="server" class="labels" ID="Label2" Font-Bold="True" Text="Category Name"></asp:Label>
            <br />
            <asp:TextBox ID="txtCategoryName" Height="25px" runat="server" Width="300px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCategoryName" ErrorMessage="Takes string value only!" ForeColor="Red" ValidationGroup="CategoryGroup" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCategoryName" ErrorMessage="Field must not be empty!" ForeColor="Red" ValidationGroup="CategoryGroup"></asp:RequiredFieldValidator>
        </div>
        
        <br />
        <br />
        <div>
            <asp:Button ID="btnSubmit" class="btnSubmit" runat="server" Text="SUBMIT" OnClick="btninsert_Click" ValidationGroup="CategoryGroup" Height="37px" Width="106px" />
        </div>
        <br />
        <br />
        <br />
        <div>
            <asp:GridView ID="categoryGridView" runat="server" DataKeyNames="CATEGORY_ID" Height="369px" HorizontalAlign="Justify" PageSize="15" Width="1136px" CellPadding="5" CellSpacing="5" GridLines="Horizontal">
                </asp:GridView>
        </div>
        
    </div>

</asp:Content>
