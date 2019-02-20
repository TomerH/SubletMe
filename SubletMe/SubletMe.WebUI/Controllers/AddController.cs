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

        public AddController(IRepository<Apartment> apartments, IRepository<Room> rooms)
        {
            this.apartments = apartments;
            this.rooms = rooms;
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
        public ActionResult AddApartment(Apartment Apartment)
        {
            if(!ModelState.IsValid)
            {
                return View(Apartment);
            }
            else
            {
                apartments.Insert(Apartment);
                apartments.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult AddRoom()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRoom(Room Room)
        {
            if (!ModelState.IsValid)
            {
                return View(Room);
            }
            else
            {
                rooms.Insert(Room);
                rooms.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}