using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

public static class HtmlHelperExtensions
{
    public static MvcHtmlString RenderMenu(this HtmlHelper helper,
        IEnumerable<MenuItem> menuItems)
    {
        if (!menuItems.Any())
        {
            return MvcHtmlString.Create(String.Empty);
        }
            
        StringBuilder str = new StringBuilder();
        foreach (var item in menuItems)
        {
            TagBuilder listItem = new TagBuilder("li");
            listItem.InnerHtml = CreateLink(item);
            if (item.MenuItems.Any())
            {
                listItem.InnerHtml += helper.RenderMenu(item.MenuItems);
            }
            str.Append(listItem.ToString());
        }
           
        TagBuilder list = new TagBuilder("ul");
        list.InnerHtml = str.ToString();
        return MvcHtmlString.Create(list.ToString());
    }

    private static string CreateLink(MenuItem item)
    {
        TagBuilder link = new TagBuilder("a");
        link.MergeAttribute("href", item.Link);
        link.SetInnerText(item.Title);
        return link.ToString();
    }
}