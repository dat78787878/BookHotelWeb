using BookHotelWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace BookHotelWeb.Controllers
{
    public class RoomController : ApiController
    {
        private DBContext con = new DBContext();
        /// <summary>
        /// Get Api : Các phòng
        /// url : api/Room
        /// </summary>
        /// <returns>Danh sách thông tin của các phòng</returns>
        public IQueryable<Room> GetRooms()
        {
            return con.Rooms;
        }
        /// <summary>
        /// Get : api/Room/id
        /// </summary>
        /// <param name="id">mã của phòng</param>
        /// <returns></returns>
        public IHttpActionResult GetRoom(int id)
        {
            var room = con.Rooms.Find(id);
            if (room == null)
            {
                return NotFound();
            }
            return Ok(room);
        }
    }
}