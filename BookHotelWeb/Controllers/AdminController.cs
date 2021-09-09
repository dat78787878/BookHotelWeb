using BookHotelWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookHotelWeb.Controllers
{
    public class AdminController : Controller
    {
        private DBContext con = new DBContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Bảng chứa thông tin các khách sạn
        /// </summary>
        /// <returns></returns>
        public ActionResult HotelTable()
        {
            var hotels = con.Hotels.ToList();
            var sqlCommand = "Proc_GetRoomAmount";
            var roomAmounts = con.Database.SqlQuery<Int32>(sqlCommand).ToList();

            var list = new List<int>();
            var averagePrices = new List<int>();
            sqlCommand = "Proc_GetPricesHotel @idHotel";

            foreach (var hotel in hotels)
            {
                list = con.Database.SqlQuery<Int32>(sqlCommand, new SqlParameter("@idHotel", hotel.IdHotel)).ToList();
                averagePrices.Add(BookHotelWeb.Entity.Common.GetRoomAveragePrice(list));
            }

            ViewBag.AveragePrices = averagePrices;
            ViewBag.RoomAmounts = roomAmounts;
            return View(hotels);
        }

        /// <summary>
        /// Bảng các phòng
        /// </summary>
        /// <returns></returns>
        public ActionResult RoomTable()
        {
            var rooms = con.Rooms.ToList();
            

            var hotels = new List<Hotel>();

            foreach (var room in rooms)
            {
                var idHotel = room.IdHotel;
                hotels.Add(con.Hotels.Find(idHotel));
            }

            ViewBag.Hotels = hotels;
            ViewBag.Rooms = rooms;
            return View();
        }

        public ActionResult Insert()
        {
            return View();
        }
        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        public ActionResult HotelEdit(int id)
        {
            var hotel = con.Hotels.Find(id);
            return View(hotel);
        }
        public ActionResult HotelEdit(Hotel hotel)
        {
            try
            {
                var hotels = con.Hotels.ToList();
                var h = con.Hotels.Find(hotel.IdHotel);
                
                h.HotelName = hotel.HotelName;
                h.Evaluate = hotel.Evaluate;
                h.HotelAddress = hotel.HotelAddress;
                h.HotelIntroduce = hotel.HotelIntroduce;
                con.SaveChanges();
                return RedirectToAction("HotelTable");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi : " + ex.ToString());
                return View();
            }
        }
        public ActionResult DeleteHotel(int id)
        {
            try
            {
                var rooms = con.Rooms.Where(r => r.IdHotel == id).ToList();
                foreach (var room in rooms)
                {
                    con.Rooms.Remove(room);
                }
                var bookings = con.BookingDetails.Where(r => r.IdHotel == id).ToList();
                foreach (var booking in bookings)
                {
                    con.BookingDetails.Remove(booking);
                }
                var comments = con.Comments.Where(r => r.IdHotel == id).ToList();
                foreach (var comment in comments)
                {
                    con.Comments.Remove(comment);
                }

                var hotel = con.Hotels.Find(id);
                con.Hotels.Remove(hotel);
                con.SaveChanges();
                return RedirectToAction("HotelTable");

            }
            catch
            {
                Console.WriteLine("Lỗi");
                return View("HotelTable");
            }

        }
        public ActionResult Delete(int id)
        {
            try
            {
                var room = con.Rooms.Find(id);
                con.Rooms.Remove(room);
                con.SaveChanges();
                return RedirectToAction("RoomTable");

            }
            catch
            {
                Console.WriteLine("Lỗi");
                return View("RoomTable");
            }

        }


    }
}