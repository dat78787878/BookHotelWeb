using BookHotelWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookHotelWeb.Controllers
{
    public class LoginController : Controller
    {
        private DBContext con = new DBContext();
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Mes = TempData["Mes"];
            return View();
        }

        // GET: Login
        public RedirectResult Index(Account acc)
        {
            var accounts = con.Accounts;
            foreach (var account in accounts)
            {
                if (acc.Username == account.Username && acc.Password == account.Password && account.IsAdmin == true)
                {
                    TempData["Name"] = acc.Username;
                    TempData["Pass"] = acc.Password;
                    
                    return Redirect("/Admin/Index");

                }
                else if (acc.Username == account.Username && acc.Password == account.Password && account.IsAdmin == false)
                {
                    if (Session["id"] == null)
                    {
                        TempData["Name"] = acc.Username;
                        TempData["Pass"] = acc.Password;
                        Session["Username"] = acc.Username;
                        return Redirect("/Home/Index");
                    }
                    else
                    {
                        Session["Username"] = acc.Username;
                        var id = Session["id"];
                        return Redirect("/Payment/AddItem/" + id);
                    }

                }
                else
                {
                    //TempData["Name"] = acc.Username;
                    //TempData["Pass"] = acc.Password;
                    acc.Username = acc.Username;
                    acc.Password = acc.Password;
                    TempData["Mes"] = "Tài khoản hoặc mật khẩu không chính xác";
                }
            }
            ViewData["Message"] = "Tài khoản hoặc mật khẩu không đúng";
            return Redirect("/Login");

        }
        public ActionResult Logout()
        {
            Session["Username"] = null;
            return Redirect("/Home/Index");
        }
    }
}