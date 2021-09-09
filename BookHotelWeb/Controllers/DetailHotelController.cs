using BookHotelWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookHotelWeb.Controllers
{
    public class DetailHotelController : Controller
    {
        private DBContext con = new DBContext();
        // GET: Hien
        public ActionResult Index(int id)
        {
            // id hotel
            //var hotel = GetHotelById(id);
            // Lấy thông tin room có id room là room là 5 
            var hotel = con.Hotels.Find(id);
            var srcImageHotel = "/DataBase/images/hotels";
            switch (hotel.IdCity)
            {
                case 1:
                    srcImageHotel += "/hanoi";
                    break;
                case 2:
                    srcImageHotel += "/danang";
                    break;
                case 3:
                    srcImageHotel += "/vungtau";
                    break;
                case 4:
                    srcImageHotel += "/nhatrang";
                    break;
                case 5:
                    srcImageHotel += "/phuquoc";
                    break;
                case 6:
                    srcImageHotel += "/halong";
                    break;
                case 7:
                    srcImageHotel += "/hochiminh";
                    break;
                case 8:
                    srcImageHotel += "/haiphong";
                    break;
                case 9:
                    srcImageHotel += "/dalat";
                    break;
                case 10:
                    srcImageHotel += "/hoian";
                    break;
            }
            ViewBag.SourceImageHotel = srcImageHotel;
            hotel.Image1 += ".jpg";
            hotel.Image2 += ".jpg";
            hotel.Image3 += ".jpg";
            hotel.Image4 += ".jpg";
            hotel.Image5 += ".jpg";
            hotel.Image6 += ".jpg";
            hotel.Image7 += ".jpg";
            hotel.Image8 += ".jpg";

            // lấy ra phòng đầu tiên của hotel có ID = 5
            var rooms = con.Rooms.Where(r => r.IdHotel == id);
            ViewBag.Rooms = rooms;
            var room = con.Rooms.Where(s => s.IdHotel == id).FirstOrDefault();
            ViewBag.Price = room.Price;
            
            

            // tách thông tin phòng
            ViewBag.Informations = room.RoomInformation.Split(',');
            // tách thông tin dịch vụ phòng
            ViewBag.Services = room.RoomService.Split(',');
            //tách thông tin giới thiệu phòng
            ViewBag.Introduces = room.RoomIntroduce.Split(',');
            Session["IdHotel"] = id;
            
            return View(hotel);
        }
        public RedirectResult Payment()
        {
            return Redirect("/Payment/Index");
        }
    }
}


