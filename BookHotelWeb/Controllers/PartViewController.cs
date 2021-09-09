using BookHotelWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookHotelWeb.Controllers
{
    public class PartViewController : Controller
    {
        private DBContext con = new DBContext();
        // GET: PartView
        public ActionResult Header()
        {
            return View();
        }
        public ActionResult Footer()
        {
            return View();
        }
        public ActionResult SearchBox()
        {
            return View();
        }
        public ActionResult NavbarAdmin()
        {
            return View();
        }


        public ActionResult HotelDialog()
        {
            return View();
        }
        public ActionResult RoomDialog()
        {
            return View();
        }
        public ActionResult Comment()
        {
            var id = Int32.Parse(Session["IdHotel"].ToString());
            ViewBag.Comments = con.Comments.Where(m => m.IdHotel == id);

            return View();
        }
    }
}