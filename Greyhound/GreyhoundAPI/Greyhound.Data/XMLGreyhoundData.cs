using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Greyhound.Common;
using Greyhound.Data.Properties;
using Greyhound.Model;
using System.Reflection;

namespace Greyhound.Data
{
    public class XMLGreyhoundData : IGreyhoundData
    {
        private Dictionary<Type, object> repositories;

       

        public XMLGreyhoundData()
        {
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<UpcomingEvents> UpcomingEvents
        {
            get
            {
                return this.GetRepository<UpcomingEvents>(WebConstants.RACE_EVENT_FILE_PATH);
            }
        }

        private IRepository<T> GetRepository<T>(string xmlFilePath) where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(XMLRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, xmlFilePath));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
