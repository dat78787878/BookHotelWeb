using BookHotelWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookHotelWeb.Controllers
{
    public class HomeController : Controller
    {
        private DBContext con = new DBContext();
        public ActionResult Index()
        {
            //Favorite Cities
            var cities = con.Cities.Where(c => c.IdCity==1 || c.IdCity==7 || c.IdCity==2 || c.IdCity == 5);
            var sourceImage = "/DataBase/images/cities/";
            foreach (var city in cities)
            {
                city.CityImage = sourceImage + city.CityImage + ".jpg";
            }
            ViewBag.Cities = cities;
            //Top Hotel
            var hotels = con.Hotels.Where(h => h.Evaluate == "9,5");
            
            foreach (var hotel in hotels)
            {
                var sourceImage1 = "/DataBase/images/hotels";
                switch (hotel.IdCity)
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
                hotel.Image1 += ".jpg";
                var s = sourceImage1 +"/"+ hotel.Image1;
                hotel.Image1 = s;
            }
            ViewBag.Hotels = hotels;

            var sqlCommand = "Proc_GetHotelCheapPrice";
            var hotelPriceCheaps = con.Database.SqlQuery<Hotel>(sqlCommand).ToList();
            foreach (var hotel in hotelPriceCheaps)
            {
                var sourceImage1 = "/DataBase/images/hotels";
                switch (hotel.IdCity)
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
                hotel.CoverImage += ".jpg";
                var s = sourceImage1 + "/" + hotel.CoverImage;
                hotel.CoverImage = s;
            }
            ViewBag.HotelPriceCheaps = hotelPriceCheaps;
            return View();
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            //var a = 2;
            //if ()
            //{
            //    return RedirectToAction("index", 1);
            //}
            var cities = con.Cities;
            foreach(var city in cities)
            {
                bool check = city.CityName.ToLower().Contains(search.ToLower());
                if (check)
                {
                    return Redirect("/HotelList/Index/"+city.IdCity);
                }
            }

            var hotels = con.Hotels;
            foreach (var hotel in hotels)
            {
                bool check = hotel.HotelName.ToLower().Contains(search.ToLower());
                if (check)
                {
                    return Redirect("/DetailHotel/Index/" + hotel.IdHotel);
                }
            }
            //Theo Thanh Pho

            //Theo Ten Khach San
            return Redirect("/DetailHotel/Index/1");
        }
    }
}