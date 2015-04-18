using Greyhound.Common.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Greyhound.Common
{
    public static class WebConstants
    {
         public static readonly string RACE_EVENT_FILE_PATH =
         HttpRuntime.AppDomainAppPath + Settings.Default.RaceFile;

         public static readonly string RACE_EVENT_FILE_NAME =
         Settings.Default.RaceFile;
    }
}
