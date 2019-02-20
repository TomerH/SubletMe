using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SubletMe.WebUI.Controllers
{
    public class HomeController : Controller
    {
        //IRepository<Apartme> 
        public ActionResult Index(string City)
        {
            if (City != null)
            {
                return View();
            }
            else
            {
                return View();
            }
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