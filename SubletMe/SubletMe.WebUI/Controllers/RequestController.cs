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

        public RequestController(IRepository<Request> requests)
        {
            this.requests = requests;
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
        public ActionResult RequestApartment(Request Request)
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
                Request.Kind = "Apartment";
                requests.Insert(Request);
                requests.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult RequestRoom()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RequestRoom(Request Request)
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
                Request.Kind = "Room";
                requests.Insert(Request);
                requests.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}