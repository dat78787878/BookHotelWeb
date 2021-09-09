using BookHotelWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace BookHotelWeb.Controllers
{
    public class BookingDetailController : ApiController
    {
        private DBContext con = new DBContext();
        /// <summary>
        /// Get Api : các chi tiết đặt phòng
        /// url : api/BookingDetail
        /// </summary>
        /// <returns>Danh sách thông tin chi tiết các thông tin đặt phòng</returns>
        public IQueryable<BookingDetail> GetBookingDetails()
        {
            return con.BookingDetails;
        }
        /// <summary>
        /// Get : api/BookingDetail/id
        /// </summary>
        /// <param name="id">mã của chi tiết đăt phòng</param>
        /// <returns></returns>
        public IHttpActionResult GetBookingDetail(int id)
        {
            var bookingDetail = con.BookingDetails.Find(id);
            if (bookingDetail == null)
            {
                return NotFound();
            }
            return Ok(bookingDetail);
        }
    }
}