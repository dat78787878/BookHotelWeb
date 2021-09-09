using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookHotelWeb.Models;

namespace BookHotelWeb.Controllers
{
    public class HotelListController : Controller
    {
        DBContext DB = new DBContext();
        // GET: Thiep
        public ActionResult Index(int id)
        {
            var hotel = DB.Hotels.Where(x => x.IdCity == id);
            var city = DB.Cities.Find(id);
            foreach (var h in hotel)
            {
                var sourceImage1 = "/DataBase/images/hotels";
                switch (h.IdCity)
                {
                    case 1:
                        sourceImage1 += "/hanoi";
                        break;
                    case 2:
                        sourceImage1 += "/danang";
                        break;
                    case 3:
                        sourceImage1 += "/vungtau";
                        break;
                    case 4:
                        sourceImage1 += "/nhatrang";
                        break;
                    case 5:
                        sourceImage1 += "/phuquoc";
                        break;
                    case 6:
                        sourceImage1 += "/halong";
                        break;
                    case 7:
                        sourceImage1 += "/hochiminh";
                        break;
                    case 8:
                        sourceImage1 += "/haiphong";
                        break;
                    case 9:
                        sourceImage1 += "/dalat";
                        break;
                    case 10:
                        sourceImage1 += "/hoian";
                        break;
                }
                h.Image1 += ".jpg";
                var s = sourceImage1 + "/" + h.Image1;
                h.Image1 = s;
            }    
            ViewBag.Hotels = hotel;
            ViewBag.City = city;
            return View(city);
        }
    }
}