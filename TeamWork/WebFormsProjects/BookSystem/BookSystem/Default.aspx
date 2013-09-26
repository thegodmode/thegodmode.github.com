<%@ Page Title="Book" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BookSystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Books</h1>
    <fieldset>
        <asp:TextBox runat="server" ID="searchText" />  
        <asp:Button Text="Search" runat="server" ID="Search" OnClick="Search_Click" />
        <asp:CustomValidator ErrorMessage="Too Long Text" ControlToValidate="searchText" runat="server" ID="searchValidator"/>
    </fieldset>

    <div class="container">
    <asp:Repeater runat="server" ID="books" 
                  ItemType="BookSystem.BooksModel.Category"
                  SelectMethod="books_GetData">
        <ItemTemplate>
            <div class="span4">
                <h2><%#: Item.Name %></h2>
                <ul>
                    <asp:Repeater runat="server" DataSource="<%# Item.Books %>" 
                                  ItemType="BookSystem.BooksModel.Book">
                        <ItemTemplate>

                            <li>
                                <a href="BookDetails?id=<%#:Item.Id%>"><%#: Item.Title %> by <%#:Item.Author %></a>
                            </li>

                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    </div>
</asp:Content>
