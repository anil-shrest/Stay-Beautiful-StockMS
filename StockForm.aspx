<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockForm.aspx.cs" MasterPageFile="~/Site.Master" Inherits="StayBeautifulSMS.StockForm" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <% if (Session["user_type"].ToString() == "Staff")
            {%>
            <div>
                <asp:Label ID="Label7" runat="server" Text></asp:Label>
            </div>
        <%}
    else
    { %>
            <div>
                <asp:Label ID="Label8" runat="server" Text="Admin"></asp:Label>
            </div>
        <%} %>
        <div>
            <asp:Label ID="Label1" class="headings" runat="server" Text="Item Stock Details"></asp:Label>
        </div>
        <br />
        <br />
        <div>
            <asp:Label ID="Label6" CssClass="labels" runat="server" Text="Item"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="item_name" DataValueField="item_id"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT [item_id], [item_name] FROM [Items]"></asp:SqlDataSource>
        </div>
        <br />
        <div>
            <asp:Label ID="Label2" class="labels" runat="server" Text="Updated Quantity"></asp:Label>
            <br />
            <asp:TextBox ID="txtUpdatedQuantity" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUpdatedQuantity" ErrorMessage="Field must not be empty!" ForeColor="Red" ValidationGroup="StockGroup"></asp:RequiredFieldValidator>
        </div>
        <br />
        <div>
            <asp:Label ID="Label3" class="labels" runat="server" Text="Date Of Stock"></asp:Label>
            <br />
            <asp:TextBox ID="txtDateOfStock" type="Date" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDateOfStock" ErrorMessage="Field must not be empty!" ForeColor="Red" ValidationGroup="StockGroup"></asp:RequiredFieldValidator>
        </div>
        <br />
        <div>
            <asp:Label ID="Label4" class="labels" runat="server" Text="Manufactured Date"></asp:Label>
            <br />
            <asp:TextBox ID="txtMfd" type="Date" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMfd" ErrorMessage="Field must not be empty!" ForeColor="Red" ValidationGroup="StockGroup"></asp:RequiredFieldValidator>
        </div>
        <br />
        <div>
            <asp:Label ID="Label5" class="labels" runat="server" Text="Expiry Date"></asp:Label>
            <br />
            <asp:TextBox ID="txtExp" type="Date" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtExp" ErrorMessage="Field must not be empty!" ForeColor="Red" ValidationGroup="StockGroup"></asp:RequiredFieldValidator>
        </div>
        <br />
        <br />
        <div>
            <asp:Button ID="btnInsert" runat="server" Text="SUBMIT" OnClick="btnInsert_Click" ValidationGroup="StockGroup"/>
        </div>
        <br />
        <br />
        <br />
        <div>
            <asp:GridView ID="stockGridView" runat="server" DataKeyNames="Stock ID" Height="369px" HorizontalAlign="Justify" PageSize="15" Width="1136px" CellPadding="5" CellSpacing="5" GridLines="Horizontal"  OnRowEditing="stockGridView_RowEditing" OnRowCancelingEdit="stockGridView_RowCancelingEdit" OnRowUpdating="stockGridView_RowUpdating" AutoGenerateEditButton="true"></asp:GridView>
        </div>
    </div>
</asp:Content>