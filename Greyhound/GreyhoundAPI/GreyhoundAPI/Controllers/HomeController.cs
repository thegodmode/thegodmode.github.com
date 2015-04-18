using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Greyhound.Common;
using GreyhoundAPI.Hubs;
using Microsoft.AspNet.SignalR;

namespace GreyhoundAPI.Controllers
{
    public class HomeController : Controller
    {
        private System.IO.FileSystemWatcher m_Watcher;

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            RegisterFileSystemWatcher();

            return View();
        }

        private void RegisterFileSystemWatcher()
        {
            m_Watcher = new System.IO.FileSystemWatcher();
            m_Watcher.Path = HttpRuntime.AppDomainAppPath;
            m_Watcher.Filter = WebConstants.RACE_EVENT_FILE_NAME;  

            m_Watcher.NotifyFilter = NotifyFilters.LastAccess |
                         NotifyFilters.LastWrite |
                         NotifyFilters.FileName |
                         NotifyFilters.DirectoryName;

            m_Watcher.Changed += new FileSystemEventHandler(OnChanged);
            m_Watcher.EnableRaisingEvents = true;
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            try
            {
                //watcher sometimes call event twice. This will fix this problem.
                m_Watcher.EnableRaisingEvents = false;
                var hubContext = GlobalHost.ConnectionManager.GetHubContext<RaceHub>();
                hubContext.Clients.All.changed();
            }
            finally
            {
                m_Watcher.EnableRaisingEvents = true;
            }
        }


    }
}
