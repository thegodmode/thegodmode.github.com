using DynamicMenu.Helpers;
using System.Collections.Generic;
using System.Xml.Serialization;

public class MenuItem
{
    [XmlAttribute(AttributeName = "Title")]
    public string Title { get; set; }

    [XmlAttribute(AttributeName = "Controller")]
    public string Controller { get; set; }

    [XmlAttribute(AttributeName = "Action")]
    public string Action { get; set; }

    [XmlArray(ElementName = "Params")]
    public List<MenuParam> MenuParams { get; set; }

    [XmlArray(ElementName = "Children")]
    public List<MenuItem> MenuItems { get; set; }
}