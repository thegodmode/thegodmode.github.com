using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Greyhound.Model
{
    public class UpcomingEvents
    {
        [XmlElement(ElementName = "RaceEvent")]
        public List<RaceEvent> RaceEvents { get; set; }
    }
}
