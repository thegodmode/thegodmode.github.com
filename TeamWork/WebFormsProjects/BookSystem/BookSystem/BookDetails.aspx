<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="BookSystem.BookDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Repeater runat="server"
                      ItemType="BookSystem.BooksModel.Book"
                      ID="details"
                      SelectMethod="details_GetData">
            <ItemTemplate>
                <header>
                    <h1><%#: Item.Title %></h1>
                    <p class="book-title"><%#: Item.Category.Name %></p>
                    <p>By <%#: Item.Author %></p>
                    <p><%#: Item.Isbn %></p>
                    <p><%#: Item.WebSite %></p>
                </header>
                <div>
                    <div><%#: Item.Description %></div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <asp:LinkButton Text="Back to books" runat="server" ID="back" OnClick="Back_Click" />
</asp:Content>
