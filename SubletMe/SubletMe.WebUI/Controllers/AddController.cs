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
    public class AddController : Controller
    {
        IRepository<Apartment> apartments;
        IRepository<Room> rooms;

        IRepository<City> cities;
        IRepository<Street> streets;

        public AddController(IRepository<Apartment> apartments, IRepository<Room> rooms, IRepository<City> cityContext, IRepository<Street> streetContext)
        {
            this.apartments = apartments;
            this.rooms = rooms;

            this.cities = cityContext;
            this.streets = streetContext;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Type)
        {
            if(Type == "Apartment") {
                return RedirectToAction("AddApartment");
            }
            else
            {
                return RedirectToAction("AddRoom");
            }
        }

        public ActionResult AddApartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddApartment(Apartment Apartment, string Create, string prefix, bool isStreet = false, string cityPrefix = null, string streetPrefix = null)
        {
            if (!string.IsNullOrEmpty(Create))
            {
                if (!ModelState.IsValid)
                {
                    return View(Apartment);
                }
                else
                {
                    if (User.Identity.IsAuthenticated)
                    {
                        var Id = User.Identity.GetUserId();
                        Apartment.UserId = Id;
                    }
                    Apartment.State = "ישראל";
                    apartments.Insert(Apartment);
                    apartments.Commit();
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

        public ActionResult AddRoom()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRoom(Room Room, string Create, string prefix, bool isStreet = false, string cityPrefix = null, string streetPrefix = null)
        {
            if (!string.IsNullOrEmpty(Create))
            {
                if (!ModelState.IsValid)
                {
                    return View(Room);
                }
                else
                {
                    if (User.Identity.IsAuthenticated)
                    {
                        var Id = User.Identity.GetUserId();
                        Room.UserId = Id;
                    }
                    Room.State = "ישראל";
                    rooms.Insert(Room);
                    rooms.Commit();
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