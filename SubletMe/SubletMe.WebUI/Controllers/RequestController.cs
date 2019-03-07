using Microsoft.AspNet.Identity;
using SubletMe.Core.Contracts;
using SubletMe.Core.Models;
using SubletMe.Services;
using SubletMe.WebUI.Models;
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

        IRepository<Apartment> apartments;
        IRepository<Room> rooms;

        IRepository<City> cities;
        IRepository<Street> streets;

        Mailer mailer = new Mailer();

        public RequestController(IRepository<Request> requestContext, IRepository<City> cityContext, IRepository<Street> streetContext, IRepository<Apartment> apartmentContext, IRepository<Room> roomContext)
        {
            this.requests = requestContext;

            this.apartments = apartmentContext;
            this.rooms = roomContext;

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
                    var Id = "";

                    if (User.Identity.IsAuthenticated)
                    {
                        Id = User.Identity.GetUserId();
                        Request.UserId = Id;
                    }

                    Request.State = "ישראל";
                    Request.Kind = "Apartment";

                    List<Apartment> MatchedApartmens = apartments.Collection().Where(A => A.City == Request.City).ToList();
                    var context = new ApplicationDbContext();

                    mailer.SendMatch(context, MatchedApartmens, Id, "דירה");

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
                    var Id = "";

                    if (User.Identity.IsAuthenticated)
                    {
                        Id = User.Identity.GetUserId();
                        Request.UserId = Id;
                    }

                    Request.State = "ישראל";
                    Request.Kind = "Room";

                    List<Room> MatchedRooms = rooms.Collection().Where(A => A.City == Request.City).ToList();
                    var context = new ApplicationDbContext();

                    mailer.SendMatch(context, MatchedRooms, Id, "חדר");

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