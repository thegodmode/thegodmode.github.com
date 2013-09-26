<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="BookSystem.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        <asp:Label Text="" runat="server" ID="label" />
    </h1>
    <asp:Repeater runat="server" ID="resultRepeater" SelectMethod="resultRepeater_GetData"
                  ItemType="BookSystem.BooksModel.Book">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <a href="BookDetails?id=<%#:Item.Id%>"><%#: Item.Title %> by <%#:Item.Author %></a>
                <span>(Category: <%#: Item.Category.Name %>)</span>
            </li>

        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
    <asp:LinkButton Text="Back to books" runat="server" ID="Back" OnClick="Back_Click" />
</asp:Content>
