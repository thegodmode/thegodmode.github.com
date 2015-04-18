using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Greyhound.Model
{
    public class Entry
    {
        [XmlAttribute(AttributeName = "ID")]
        public int ID { get; set; }

        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
        
        [XmlAttribute(AttributeName = "OddsDecimal")]
        public decimal OddsDecimal { get; set; }

    }
}
