using BookHotelWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace BookHotelWeb.Controllers
{
    public class CityController : ApiController
    {
        private DBContext con = new DBContext();
        /// <summary>
        /// Get Api : Các thành phố (City)
        /// url : api/City
        /// </summary>
        /// <returns></returns>
        public IQueryable<City> GetCities()
        {
            return con.Cities;
        }
        /// <summary>
        /// Get : api/City/id
        /// </summary>
        /// <param name="id">mã của Thành phố</param>
        /// <returns></returns>
        public IHttpActionResult GetCity(int id)
        {
            var city = con.Cities.Find(id);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }
    }
}