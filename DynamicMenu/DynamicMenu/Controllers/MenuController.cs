using DynamicMenu.Constants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace DynamicMenu.Controllers
{
    public class MenuController : Controller
    {
        //
        // GET: /Menu/
        //[OutputCache(Duration=60)]
        public ActionResult Create()
        {
            if (System.Web.HttpContext.Current.Cache["menu"] == null)
            {
                System.Web
                      .HttpContext
                      .Current
                      .Cache
                      .Add("menu", this.Deserialize(), null, DateTime.Now.AddMinutes(1),
                    System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
            }
            
            var menuItems = (IEnumerable<MenuItem>)
            System.Web.HttpContext.Current.Cache["menu"];

            return PartialView("_Create", menuItems);
        }

        private IEnumerable<MenuItem> Deserialize()
        {
            XmlSerializer seriazlizer = new XmlSerializer(typeof(List<MenuItem>));
            using (StreamReader reader = new StreamReader(WebConstants.MENU_URL))
            {
                object objmenuItems = seriazlizer.Deserialize(reader);
                var menuItems = objmenuItems as IEnumerable<MenuItem>;

                return menuItems;
            }
        }
    }
}