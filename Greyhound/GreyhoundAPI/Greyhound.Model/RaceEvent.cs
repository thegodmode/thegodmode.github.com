using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Greyhound.Model
{
    public class RaceEvent
    {
        [XmlAttribute(AttributeName = "ID")]
        public int ID { get; set; }

        [XmlAttribute(AttributeName = "EventNumber")]
        public int EventNumber { get; set; }

        [XmlAttribute(AttributeName = "EventTime")]
        public DateTime EventTime { get; set; }

        [XmlAttribute(AttributeName = "FinishTime")]
        public DateTime FinishTime { get; set; }

        [XmlAttribute(AttributeName = "Distance")]
        public int Distance { get; set; }

        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "Entry")]
        public List<Entry> Entries { get; set; }
    }
}
