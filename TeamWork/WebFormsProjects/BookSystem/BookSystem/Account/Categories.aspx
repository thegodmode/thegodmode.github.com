<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="BookSystem.Account.Categories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:CustomValidator ErrorMessage="Category Name must be between (5-50) symbols length" ControlToValidate="Name" runat="server" ID="customValidator" Display="Dynamic" />
    <asp:Literal Text="" runat="server" ID="DbError" />
    <h1>Edit Categories</h1>
    <asp:GridView runat="server"
                  ItemType="BookSystem.BooksModel.Category"
                  PageSize="5" AllowPaging="true" 
                  ID="CategoriesView"
                  AllowSorting="true" AutoGenerateColumns="false"
                  SelectMethod="Categories_GetData" DataKeyNames="Id">
        <Columns>
            <asp:BoundField HeaderText="Category Name" SortExpression="Name" DataField="Name" />
            <asp:TemplateField >
                <HeaderTemplate>
                    <h4>Action</h4>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:LinkButton Text="Edit" runat="server" ID="EditBtn" CommandArgument="<%# Item.Id %>" OnCommand="EditBtn_Click" />
                    <asp:LinkButton Text="Delete" runat="server" ID="DeleteBtn" CommandArgument="<%# Item.Id %>" OnCommand="DeleteBtn_Command"  />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:LinkButton Text="Create New" runat="server" ID="NewCategoryBtn" OnClick="NewCategoryBtn_Click" />
    <div id="categoryTemplate" runat="server">
        <fieldset runat="server">
            <legend runat="server" id="title">Edit Category</legend>
            <asp:Label Text="Category:" runat="server" AssociatedControlID="Name" />
            <asp:TextBox runat="server" ID="Name" placeholder="CategoryName"/>

        </fieldset>
        <asp:LinkButton Text="Create" runat="server" ID="ActionBtn" OnCommand="ActionBtn_Command" />
        <asp:LinkButton Text ="Cancel" runat="server" ID="CancelBtn" OnClick="CancelBtn_Click" />
    </div>
    <asp:LinkButton Text="Back to Books" runat="server" ID="Back" OnClick="Back_Click" />
</asp:Content>
