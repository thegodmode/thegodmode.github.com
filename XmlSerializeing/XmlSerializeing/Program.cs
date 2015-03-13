using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XmlSerializeing
{
    class Program
    {
        static void Main(string[] args)
        {

            XmlSerializer s = new XmlSerializer(typeof(List<MenuItem>));
            using (StreamReader r = new StreamReader(@"c:\users\bozhidar.penchev\documents\visual studio 2013\Projects\XmlSerializeing\XmlSerializeing\Test.xml"))
            {
                object obj = s.Deserialize(r);
                var menuItems = obj as IEnumerable<MenuItem>;
                CreateItem(menuItems);
            }

        }

        private static void CreateItem(IEnumerable<MenuItem> menuItems)
        {

            foreach (var item in menuItems)
            {
                Console.WriteLine(item.Title);
                Console.WriteLine(item.Link);
                if (item.MenuItems.Count > 0)
                {
                    CreateItem(item.MenuItems);
                }

            }


        }
    }


    public class MenuItem
    {
        [XmlAttribute(AttributeName="Title")]
        public string Title { get; set; }
        [XmlAttribute(AttributeName="Link")]
        public string Link { get; set; }
        [XmlArray(ElementName="Children")]
        public List<MenuItem> MenuItems { get; set; }

    }
}
