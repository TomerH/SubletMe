using Newtonsoft.Json.Serialization;
using SubletMe.Core.Contracts;
using SubletMe.Core.Models;
using SubletMe.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SubletMe.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepository<City> cities;
        IRepository<Street> streets;

        public HomeController(IRepository<City> cityContext, IRepository<Street> streetContext)
        {
            this.cities = cityContext;
            this.streets = streetContext;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Index(string prefix, bool isStreet = false, string cityPrefix = null, string streetPrefix = null)
        {
            dynamic AdreessType;

            if (isStreet)
            {
                string CityChosen = cityPrefix;
                AdreessType = (from C in streets.Collection()
                               where C.Name_He.ToLower().StartsWith(prefix.ToLower())
                               && C.CityName.Equals(CityChosen)
                               select new { C.Name_He });
            }
            else
            {
                AdreessType = (from C in cities.Collection()
                               where C.Name_He.ToLower().StartsWith(prefix.ToLower())
                               select new { C.Name_He });
            }

            return Json(AdreessType, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}