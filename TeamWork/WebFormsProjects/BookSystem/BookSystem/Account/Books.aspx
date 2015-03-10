<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="BookSystem.Account.Books" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit Books</h1>
    <asp:Literal Text="" runat="server" ID="errorSaveToDB"/>
    <asp:GridView runat="server" ItemType="BookSystem.BooksModel.Book"
                  AllowPaging="true" PageSize="5" AllowSorting="true" ID="EditBooks"
                  SelectMethod="EditBooks_GetData" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Title" SortExpression="Title" HeaderText="Title" />
            <asp:BoundField DataField="Author" SortExpression="Author" HeaderText="Author" />
            <asp:BoundField DataField="Isbn" SortExpression="Isbn" HeaderText="ISBN" />
            <asp:TemplateField SortExpression="WebSite" HeaderText="Web Site">
                <ItemTemplate>
                    <a href="<%#: Item.WebSite %>"><%#: Item.WebSite %></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Category.Name" HeaderText="Category"/>
            <asp:TemplateField >
                <HeaderTemplate>
                    <h4>Action</h4>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:LinkButton Text="Edit" runat="server" ID="EditBtn" CommandArgument="<%# Item.Id %>" OnCommand="EditBtn_Command" />
                    <asp:LinkButton Text="Delete" runat="server" ID="DeleteBtn" CommandArgument="<%# Item.Id %>" OnCommand="DeleteBtn_Command"  />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:LinkButton Text="Create New" runat="server" ID="NewBookBtn" OnClick="NewBookBtn_Click" />

    <asp:Panel runat="server" id="BookTemplate">
        <div>
            <fieldset runat="server">
                <legend runat="server" id="title">Create Book</legend>

                <asp:Label Text="Title:" runat="server" AssociatedControlID="BookTitle"/>
                <asp:TextBox runat="server" ID="BookTitle" placeholder="Book Title" Text="Emptyy" />
                <asp:RequiredFieldValidator ErrorMessage="Required!" ControlToValidate="BookTitle" runat="server" />
                <asp:RegularExpressionValidator ErrorMessage="Book Title must be between 5 and 50 char length"
                                                ControlToValidate="BookTitle" runat="server" ValidationExpression="[\s\S]{5,50}" />

                <asp:Label Text="Author(s):" runat="server" AssociatedControlID="Author"  />
                <asp:TextBox runat="server" ID="Author"  placeholder=" Enter Author(s)" Text="Emptyyyy"/>
                <asp:RequiredFieldValidator ErrorMessage="Required!" ControlToValidate="Author" runat="server" />
                <asp:RegularExpressionValidator ErrorMessage="Author must be between 5 and 50 char length"
                                                ControlToValidate="Author" runat="server" ValidationExpression="[\s\S]{5,50}" />

                <asp:Label Text="Isbn:" runat="server" AssociatedControlID="Isbn" />
                <asp:TextBox runat="server" ID="Isbn" placeholder="Enter Isbn" Text="Emptyyyy"/>
                <asp:RegularExpressionValidator ErrorMessage="Isbn must be between no more than 13 char length"
                                                ControlToValidate="Isbn" runat="server" ValidationExpression="[\s\S]{5,50}" />

                <asp:Label Text="WebSite:" runat="server" AssociatedControlID="WebSite" />
                <asp:TextBox runat="server" ID="WebSite" placeholder="Enter Web Site" Text="Emptyyyy"/>
                <asp:RegularExpressionValidator ErrorMessage="WebSite must be minumum 5 and 50 char length"
                                                ControlToValidate="WebSite" runat="server" ValidationExpression="[\s\S]{5,}" />

                <asp:Label Text="Description:" runat="server" AssociatedControlID="Description" />
                <asp:TextBox TextMode="MultiLine" ID="Description" runat="server" placeholder="Some Description" Text="Emptyyyy"/>
                <asp:RegularExpressionValidator ErrorMessage="Description must be minumum 5 char length"
                                                ControlToValidate="Description" runat="server" ValidationExpression="[\s\S]{5,}" Display="Dynamic" />
                <asp:RequiredFieldValidator ErrorMessage="Required!" ControlToValidate="Description" runat="server" />

                <asp:Label Text="Category:" runat="server" AssociatedControlID="Categories" />
                <asp:DropDownList runat="server" ID="Categories">

                </asp:DropDownList>
            </fieldset>
            <asp:LinkButton Text="Create" runat="server" ID="ActionBtn" OnCommand="ActionBtn_Command" CommandName="Create"/>
            <asp:LinkButton Text ="Cancel" runat="server" ID="CancelBtn" OnClick="CancelBtn_Click" />
        </div>

    </asp:Panel>

    <asp:Panel runat="server" ID="DeleteTemplate">
        <fieldset>
            <h2>
                <asp:Label Text="" runat="server" ID="DeleteTextHeader" />
            </h2>
            <asp:Label Text="Title:" runat="server" AssociatedControlID="BookTitle"/>
            <asp:TextBox runat="server" ID="DeleteBookTitle" placeholder="Book Title" />
        </fieldset>
        <asp:LinkButton Text="Create" runat="server" ID="DeleteActionBtn" OnCommand="ActionBtn_Command" CommandName="Create"/>
        <asp:LinkButton Text ="Cancel" runat="server" ID="CancelBtnDelete" OnClick="CancelBtn_Click" />
    </asp:Panel>

    <asp:LinkButton Text="Back to Books" runat="server" ID="Back" OnClick="Back_Click" />
</asp:Content>
