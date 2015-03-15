using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DynamicMenu.Helpers;

public static class HtmlHelperExtensions
{
    public static MvcHtmlString RenderMenu(this HtmlHelper helper,
        IEnumerable<MenuItem> menuItems)
    {
        if (!menuItems.Any())
        {
            return MvcHtmlString.Create(String.Empty);
        }
       
        var currentUrl = helper.ViewContext
                               .HttpContext
                               .Request
                               .RawUrl
                               .ToString();

        var menu = BuildMenu(helper, menuItems, currentUrl);
        
        return menu;
    }

    private static MvcHtmlString BuildMenu(HtmlHelper helper, IEnumerable<MenuItem> menuItems, string currentUrl)
    {
        StringBuilder str = new StringBuilder();
        foreach (var item in menuItems)
        {
            TagBuilder listItem = new TagBuilder("li");
            listItem.InnerHtml = CreateLink(item, helper, currentUrl);
            if (item.MenuItems.Any())
            {
                listItem.InnerHtml += BuildMenu(helper, item.MenuItems, currentUrl);
            }
            str.Append(listItem.ToString());
        }

        TagBuilder list = new TagBuilder("ul");
        list.InnerHtml = str.ToString();
        return MvcHtmlString.Create(list.ToString());
    }

    private static string CreateLink(MenuItem item, HtmlHelper helper, string currentUrl)
    {
        var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
        var urlParams = GetParams(item.MenuParams);
        var url = urlHelper.Action(item.Action, item.Controller, urlParams);
        TagBuilder link = new TagBuilder("a");
        if (currentUrl.Equals(url))
        {
            link.MergeAttribute("class", "active");
        }
        link.MergeAttribute("href", url);
        link.SetInnerText(item.Title);
        return link.ToString();
    }
  
    private static RouteValueDictionary GetParams(IEnumerable<MenuParam> menuParams)
    {
        RouteValueDictionary dic = new RouteValueDictionary();

        foreach (var param in menuParams)
        {
            dic.Add(param.Name, param.Value);
        }

        return dic;
    }
}