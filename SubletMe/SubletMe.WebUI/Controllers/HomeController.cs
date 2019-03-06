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
        IRepository<Apartment> apartments;
        IRepository<Room> rooms;

        public HomeController(IRepository<City> cityContext, IRepository<Street> streetContext, IRepository<Apartment> apartmentContext, IRepository<Room> roomContext)
        {
            this.cities = cityContext;
            this.streets = streetContext;
            this.apartments = apartmentContext;
            this.rooms = roomContext;
        }

        public ActionResult Index(string City = null, string Street = null)
        {
            if(City == null)
            {
                ViewBag.header = "הלוח החם";

                List<Apartment> apartmentsList;
                List<Room> roomsList;

                apartmentsList = apartments.Collection().Where(A => A.HotList == true).ToList();
                roomsList = rooms.Collection().Where(A => A.HotList == true).ToList();

                SubletItemViewModel subletItemModel = new SubletItemViewModel();

                subletItemModel.Apartments = apartmentsList;
                subletItemModel.Rooms = roomsList;

                TotalViewModel totalViewModel = new TotalViewModel();

                totalViewModel.SubletItemViewModels = subletItemModel;

                return View(totalViewModel);
            }
            else
            {
                ViewBag.header = "תוצאות החיפוש:";
                if (Street == null || Street == "")
                {
                    List<Apartment> apartmentsList;
                    List<Room> roomsList;

                    apartmentsList = apartments.Collection().Where(A => A.City == City).ToList();
                    roomsList = rooms.Collection().Where(A => A.City == City).ToList();

                    if(!apartmentsList.Any() && !roomsList.Any())
                    {
                        ViewBag.header =
                            "לצערנו לא הצלחנו למצוא לך את מה שאתה מחפש :( " +
                            "אך אתה מוזמן להוסיף בקשה ואנחנו נדאג ליידע אותך במידה ונמצא בישבילך את מה שאתה מחפש";
                    }

                    SubletItemViewModel subletItemModel = new SubletItemViewModel();

                    subletItemModel.Apartments = apartmentsList;
                    subletItemModel.Rooms = roomsList;

                    TotalViewModel totalViewModel = new TotalViewModel();

                    totalViewModel.SubletItemViewModels = subletItemModel;

                    return View(totalViewModel);
                }
                else
                {
                    List<Apartment> apartmentsList;
                    List<Room> roomsList;

                    apartmentsList = apartments.Collection().Where(A => A.City == City && A.Street == Street).ToList();
                    roomsList = rooms.Collection().Where(A => A.City == City && A.Street == Street).ToList();

                    if (!apartmentsList.Any() && !roomsList.Any())
                    {
                        ViewBag.header = "לצערנו לא הצלחנו למצוא לך את מה שאתה מחפש :(";
                    }

                    SubletItemViewModel subletItemModel = new SubletItemViewModel();

                    subletItemModel.Apartments = apartmentsList;
                    subletItemModel.Rooms = roomsList;

                    TotalViewModel totalViewModel = new TotalViewModel();

                    totalViewModel.SubletItemViewModels = subletItemModel;

                    return View(totalViewModel);
                }
            }
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