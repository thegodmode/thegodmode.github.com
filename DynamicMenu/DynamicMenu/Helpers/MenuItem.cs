using System.Collections.Generic;
using System.Xml.Serialization;

public class MenuItem
{
    [XmlAttribute(AttributeName = "Title")]
    public string Title { get; set; }

    [XmlAttribute(AttributeName = "Link")]
    public string Link { get; set; }

    [XmlArray(ElementName = "Children")]
    public List<MenuItem> MenuItems { get; set; }
}