using BookHotelWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BookHotelWeb.Controllers
{
    public class HotelController : ApiController
    {
        private DBContext con = new DBContext();
        /// <summary>
        /// Get Api : Các khách sạn(Hotel)
        /// url : api/Hotel
        /// </summary>
        /// <returns></returns>
        
        public IEnumerable<Hotel> GetHotels()
        {
            var hotels = con.Hotels;
            var mHotels = new List<Hotel>();
            foreach (var hotel in hotels)
            {
                var m = new Hotel();
                m.IdHotel = hotel.IdHotel;
                m.IdCity = hotel.IdCity;
                m.HotelName = hotel.HotelName;
                m.Evaluate = hotel.Evaluate;
                m.Distance = hotel.Distance;
                m.HotelAddress = hotel.HotelAddress;
                m.HotelIntroduce = hotel.HotelIntroduce;
                m.CoverImage = hotel.CoverImage;
                m.Image1 = hotel.Image1;
                m.Image2 = hotel.Image2;
                m.Image3 = hotel.Image3;
                m.Image4 = hotel.Image4;
                m.Image5 = hotel.Image5;
                m.Image6 = hotel.Image6;
                m.Image7 = hotel.Image7;
                m.Image8 = hotel.Image8;
                mHotels.Add(m);
            }
            return mHotels;
        }
        /// <summary>
        /// Get : api/Hotel/id
        /// </summary>
        /// <param name="id">mã của khách sạn</param>
        /// <returns></returns>
        public IHttpActionResult GetHotel(int id)
        {
            var hotel = con.Hotels.Find(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return Ok(hotel);
        }
    }
}