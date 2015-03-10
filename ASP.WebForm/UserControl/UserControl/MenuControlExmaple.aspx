<%@ Page Language="C#" AutoEventWireup="true"
CodeBehind="MenuControlExmaple.aspx.cs"
Inherits="MenuUserControl.MenuControlExmaple" %>

<%@ Register tagprefix="userControls"
Assembly="UserControl"
Namespace="MenuUserControl"%>

<%@ Register src="LinksMenu.ascx" tagname="LinksMenu"
tagprefix="userControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>

        <form id="form1" runat="server">
            <div>
                <userControls:LinksMenu runat="server" ID="linkMenu" >
                    <Items>
                        <userControls:MenuItem Title="Nakov" Href="http://www.nakov.com/" runat="server" />
                        <userControls:MenuItem Title="Doncho" Href="http://www.nakov.com/" runat="server" />
                        <userControls:MenuItem Title="Joro" Href="http://www.nakov.com/" runat="server" />
                        <userControls:MenuItem Title="Kiro" Href="http://www.nakov.com/" runat="server" />
                        <userControls:MenuItem Title="Dancho" Href="http://www.nakov.com/" runat="server" />
                    </Items>
                </userControls:LinksMenu>
            </div>
        </form>
    </body>
</html>
