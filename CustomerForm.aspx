<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CustomerForm.aspx.cs" Inherits="StayBeautifulSMS.CustomerForm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>
            <asp:Label ID="Label4" class="headings" runat="server" Text="Customer Details"></asp:Label>
        </div>
        <br />
        <br />
        <div>
            <asp:Label runat="server" class="labels" ID="Label1" Font-Bold="True" Text="Customer Name"></asp:Label>
            <br />
            <asp:TextBox ID="txtCustomertName" Height="25px" runat="server" Width="300px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCustomertName" ErrorMessage="Takes string value only!" ForeColor="Red" ValidationGroup="CustomerGroup" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCustomertName" ErrorMessage="Field must not be empty!" ForeColor="Red" ValidationGroup="CustomerGroup"></asp:RequiredFieldValidator>
        </div>
        <br />

        <div>
            <asp:Label runat="server" class="labels" ID="Label2" Font-Bold="True" Text="Customer Address"></asp:Label>
            <br />
            <asp:TextBox ID="txtCustomerAddress" Height="25px" runat="server" Width="300px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCustomerAddress" ErrorMessage="Takes string value only!" ForeColor="Red" ValidationGroup="CustomerGroup" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCustomerAddress" ErrorMessage="Field must not be empty!" ForeColor="Red" ValidationGroup="CustomerGroup"></asp:RequiredFieldValidator>
        </div>
        <br />

        <div>
            <asp:Label runat="server" class="labels" ID="Label3" Font-Bold="True" Text="Contact Number"></asp:Label>
            <br />
            <asp:TextBox ID="txtCustomerPhone" Height="25px" runat="server" Width="300px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtCustomerPhone" ErrorMessage="Takes integer value only!" ForeColor="Red" ValidationGroup="CustomerGroup" ValidationExpression="^[0-9]{1,10}$"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCustomerPhone" ErrorMessage="Field must not be empty!" ForeColor="Red" ValidationGroup="CustomerGroup"></asp:RequiredFieldValidator>
        </div>
        <br />

        <div>
            <asp:Label runat="server" class="labels" ID="Label5" Font-Bold="True" Text="Loyalty Points"></asp:Label>
            <br />
            <asp:TextBox ID="txtLoyaltyPoints" Height="25px" runat="server" Width="300px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtLoyaltyPoints" ErrorMessage="Takes integer value only!" ValidationGroup="CustomerGroup" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtLoyaltyPoints" ErrorMessage="Field must not be empty!" ForeColor="Red" ValidationGroup="CustomerGroup"></asp:RequiredFieldValidator>
        </div>
        <br />
        <br />
        <div>
            <%--<asp:Button ID="btnSubmit" class="btnSubmit" runat="server" Text="SUBMIT" OnClick="btninsert_Click" ValidationGroup="CustomerGroup" />--%>
        </div>
        <br />
        <br />
        <br />
        <div>
            <asp:GridView ID="customerGridView" runat="server" DataKeyNames="CUSTOMER_ID" Height="369px" HorizontalAlign="Justify" PageSize="15" Width="1136px" CellPadding="5" CellSpacing="5" GridLines="Horizontal">
                </asp:GridView>
        </div>
    </div>
</asp:Content>

<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerForm.aspx.cs" Inherits="StayBeautifulSMS.CustomerForm" %>--%>

<%--<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">--%>


