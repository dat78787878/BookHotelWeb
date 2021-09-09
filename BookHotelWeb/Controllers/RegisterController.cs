using BookHotelWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookHotelWeb.Controllers
{
    public class RegisterController : Controller
    {
        private DBContext con = new DBContext();
        // GET: Register
        public ActionResult Index()
        {
            ViewBag.Mes = TempData["Mes"];
            return View();
        }
        public bool IsCheckUsername(Account acc)
        {
            var accounts = con.Accounts;
            foreach (var account in accounts)
            {
                // kiểm tra tài khoản có trong DB chưa 
                if(acc.Username == account.Username)
                {
                    // có thì trả về true
                    return true;
                }
            }
            // chưa tồn tại : false
            return false;
        }
        [HttpPost]
        public RedirectResult Index(Account acc)
        {
            if(String.IsNullOrEmpty(acc.Username))
            {
                TempData["Mes"] = "Tài khoản không được bỏ trống";
            }
            else if (acc.Password == "" || Request.Form["ConfirmPassword"] == "")
            {
                TempData["Mes"] = "Mật khẩu không được bỏ trống";
            }
            else if (acc.PhoneNumber == "")
            {
                TempData["Mes"] = "Số điện thoại không được bỏ trống";
            }
            else if (acc.FullName == "")
            {
                TempData["Mes"] = "Họ và tên không được bỏ trống";
            }
            else if (acc.Email == "")
            {
                TempData["Mes"] = "Email không được bỏ trống";
            }
            else if (IsCheckUsername(acc) == false)
            {
                if (acc.Password == Request.Form["ConfirmPassword"])
                {
                    TempData["Name"] = acc.Username;
                    TempData["Pass"] = acc.Password;
                    con.Accounts.Add(acc);
                    con.SaveChanges();
                    
                    TempData["Mes"] = "Đăng kí thành công";
                }
                else
                {
                    TempData["Mes"] = "Mật khẩu không trùng khớp";
                }

            }
            else
            {
                TempData["Name"] = acc.Username;
                TempData["Pass"] = acc.Password;
                TempData["Mes"] = "Đăng kí thất bại , Tài khoản đã tồn tại";
            }
            return Redirect("/Register/Index");
        }
    }
}