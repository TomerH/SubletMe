using Microsoft.AspNet.Identity;
using SubletMe.Core.Contracts;
using SubletMe.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SubletMe.WebUI.Controllers
{
    public class RequestController : Controller
    {
        IRepository<Request> requests;

        IRepository<City> cities;
        IRepository<Street> streets;

        public RequestController(IRepository<Request> requests, IRepository<City> cityContext, IRepository<Street> streetContext)
        {
            this.requests = requests;

            this.cities = cityContext;
            this.streets = streetContext;
        }

        // GET: Request
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Type)
        {
            if (Type == "Apartment")
            {
                return RedirectToAction("RequestApartment");
            }
            else
            {
                return RedirectToAction("RequestRoom");
            }
        }

        public ActionResult RequestApartment()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult RequestApartment(Request Request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(Request);
        //    }
        //    else
        //    {
        //        if (User.Identity.IsAuthenticated)
        //        {
        //            var Id = User.Identity.GetUserId();
        //            Request.UserId = Id;
        //        }
        //        Request.Kind = "Apartment";
        //        requests.Insert(Request);
        //        requests.Commit();
        //        return RedirectToAction("Index");
        //    }
        //}

        [HttpPost]
        public ActionResult RequestApartment(Request Request, string Create, string prefix, bool isStreet = false, string cityPrefix = null, string streetPrefix = null)
        {
            if (!string.IsNullOrEmpty(Create))
            {
                if (!ModelState.IsValid)
                {
                    return View(Request);
                }
                else
                {
                    if (User.Identity.IsAuthenticated)
                    {
                        var Id = User.Identity.GetUserId();
                        Request.UserId = Id;
                    }
                    Request.State = "ישראל";
                    Request.Kind = "Apartment";
                    requests.Insert(Request);
                    requests.Commit();
                    return RedirectToAction("Index");
                }
            }
            else
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

                return Json(AdreessType);
            }
        }

        public ActionResult RequestRoom()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult RequestRoom(Request Request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(Request);
        //    }
        //    else
        //    {
        //        if (User.Identity.IsAuthenticated)
        //        {
        //            var Id = User.Identity.GetUserId();
        //            Request.UserId = Id;
        //        }
        //        Request.Kind = "Room";
        //        requests.Insert(Request);
        //        requests.Commit();
        //        return RedirectToAction("Index");
        //    }
        //}

        [HttpPost]
        public ActionResult RequestRoom(Request Request, string Create, string prefix, bool isStreet = false, string cityPrefix = null, string streetPrefix = null)
        {
            if (!string.IsNullOrEmpty(Create))
            {
                if (!ModelState.IsValid)
                {
                    return View(Request);
                }
                else
                {
                    if (User.Identity.IsAuthenticated)
                    {
                        var Id = User.Identity.GetUserId();
                        Request.UserId = Id;
                    }
                    Request.State = "ישראל";
                    Request.Kind = "Room";
                    requests.Insert(Request);
                    requests.Commit();
                    return RedirectToAction("Index");
                }
            }
            else
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

                return Json(AdreessType);
            }
        }
    }
}