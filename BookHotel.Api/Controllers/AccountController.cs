using BookHotelWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
namespace BookHotelWeb.Controllers
{
    public class AccountController : ApiController
    {
        private DBContext con = new DBContext();
        /// <summary>
        /// Get Api : Các tài khoản người dùng
        /// url : api/Account
        /// </summary>
        /// <returns>Danh sách thông tin tài khoản của người dùng</returns>
        public IQueryable<Account> GetAccounts()
        {
            return con.Accounts;
        }
        /// <summary>
        /// Get : api/Account/id
        /// </summary>
        /// <param name="id">mã tài khoản</param>
        /// <returns></returns>
        public IHttpActionResult GetAccount(int id)
        {
            var account = con.Accounts.Find(id);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }

    }
}