<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" MasterPageFile="~/Site.Master" Inherits="StayBeautifulSMS.Users" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
          <div>
        <div>
            <asp:Label ID="Label4" class="headings" runat="server" Text="Users"></asp:Label>
        </div>
        <br />
        <br />
        <div>
            <asp:Label runat="server" class="labels" ID="Label1" Font-Bold="True" Text="User Name"></asp:Label>
            <br />
            <asp:TextBox ID="txtUserName" Height="25px" runat="server" Width="300px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtUserName" ErrorMessage="Takes string value only!" ForeColor="Red" ValidationGroup="CustomerGroup" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName" ErrorMessage="Field must not be empty!" ForeColor="Red" ValidationGroup="CustomerGroup"></asp:RequiredFieldValidator>
        </div>
        <br />
                <div>
            <asp:Label runat="server" class="labels" ID="Label2" Font-Bold="True" Text="User Address"></asp:Label>
            <br />
            <asp:TextBox ID="txtUserAddress" Height="25px" runat="server" Width="300px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtUserAddress" ErrorMessage="Takes string value only!" ForeColor="Red" ValidationGroup="CustomerGroup" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUserAddress" ErrorMessage="Field must not be empty!" ForeColor="Red" ValidationGroup="CustomerGroup"></asp:RequiredFieldValidator>
        </div>
        <br />
                <div>
            <asp:Label runat="server" class="labels" ID="Label3" Font-Bold="True" Text="User Contact"></asp:Label>
            <br />
            <asp:TextBox ID="txtUserContact" Height="25px" runat="server" Width="300px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtUserContact" ErrorMessage="Takes string value only!" ForeColor="Red" ValidationGroup="CustomerGroup" ValidationExpression="^[0-9]{10}+$"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUserContact" ErrorMessage="Field must not be empty!" ForeColor="Red" ValidationGroup="CustomerGroup"></asp:RequiredFieldValidator>
        </div>
        <br />
                <div>
            <asp:Label runat="server" class="labels" ID="Label5" Font-Bold="True" Text="User Username"></asp:Label>
            <br />
            <asp:TextBox ID="txtUserUsername" Height="25px" runat="server" Width="300px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtUserUsername" ErrorMessage="Takes string value only!" ForeColor="Red" ValidationGroup="CustomerGroup" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtUserUsername" ErrorMessage="Field must not be empty!" ForeColor="Red" ValidationGroup="CustomerGroup"></asp:RequiredFieldValidator>
        </div>
        <br />
        <div>
            <asp:Label runat="server" class="labels" ID="Label6" Font-Bold="True" Text="User Email"></asp:Label>
            <br />
            <asp:TextBox ID="txtUserEmail" Height="25px" runat="server" Width="300px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtUserEmail" ErrorMessage="Takes string value only!" ForeColor="Red" ValidationGroup="CustomerGroup" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtUserEmail" ErrorMessage="Field must not be empty!" ForeColor="Red" ValidationGroup="CustomerGroup"></asp:RequiredFieldValidator>
        </div>
        <br />
        <div>
            <asp:Label runat="server" class="labels" ID="Label7" Font-Bold="True" Text="User Type"></asp:Label>
            <br />
            <asp:TextBox ID="txtUserType" Height="25px" runat="server" Width="300px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtUserType" ErrorMessage="Takes string value only!" ForeColor="Red" ValidationGroup="CustomerGroup" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtUserType" ErrorMessage="Field must not be empty!" ForeColor="Red" ValidationGroup="CustomerGroup"></asp:RequiredFieldValidator>
        </div>
        <br />
        <br />
        <br />
        <br />
         <div>
             <asp:GridView ID="userGridView" DataKeyNames="USER_ID" Height="369px" HorizontalAlign="Justify" Width="1236px" CellPadding="5" CellSpacing="10" GridLines="Horizontal" runat="server" AutoGenerateEditButton="true" AutoGenerateDeleteButton="true" PageSize="15" ><%--OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" --%>

             </asp:GridView>
        </div>
    </div>
</asp:Content>