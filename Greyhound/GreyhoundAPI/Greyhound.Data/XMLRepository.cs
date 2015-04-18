using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Greyhound.Data
{
    public class XMLRepository<T> : IRepository<T> where T : class
    {
        private string xmlFilePath { get; set; }
        public XMLRepository(string xmlFilePath)
        {
            this.xmlFilePath = xmlFilePath;
        }

        public void Dispose()
        {
            this.Dispose();
        }

        public T All()
        {
            XmlSerializer seriazlizer = new XmlSerializer(typeof(T));
            using (StreamReader reader = new StreamReader(this.xmlFilePath))
            {
                object upcomingEventsObject = seriazlizer.Deserialize(reader);
                var upcomingEvents = upcomingEventsObject as T;

                return upcomingEvents;
            }
        }
    }
}
