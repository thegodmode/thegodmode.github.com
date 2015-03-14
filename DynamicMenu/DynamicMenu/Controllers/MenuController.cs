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
        [OutputCache(Duration=60)]
        public ActionResult Create()
        {
            var menuItems = this.Deserialize();
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