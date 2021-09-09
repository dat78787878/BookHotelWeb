
using BookHotelWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using System.Data.SqlClient;

namespace BookHotelWeb.Controllers
{
    public class PaymentController : Controller
    {
        private DBContext con = new DBContext();
        // GET: Dat
        public ActionResult Index()
        {
            ViewBag.Mes = TempData["Mes"];
            ViewBag.IdHotel = TempData["IdHotel"];
            ViewBag.NameHotel = TempData["NameHotel"];
            ViewBag.CoverImage = TempData["CoverImage"];
            ViewBag.SourceImageHotel = TempData["SourceImageHotel"];
            ViewBag.HotelAddress = TempData["HotelAddress"];
            ViewBag.Evaluate = TempData["Evaluate"];
            ViewBag.RoomName = TempData["RoomName"];
            ViewBag.RoomService = TempData["RoomService"];
            ViewBag.RoomInformation = TempData["RoomInformation"];
            ViewBag.MaxPerson = TempData["MaxPerson"];
            ViewBag.Price = TempData["Price"];
            ViewBag.Vat = TempData["Vat"];
            ViewBag.Total = TempData["Total"];
            ViewBag.IdRoom = TempData["IdRoom"];
            return View();
        }

        //add vao payment
        public ActionResult AddItem(int id)
        {
            Session["id"] = id;
            if (Session["Username"] == null)
            {
                return Redirect("/Login");
            }
            else
            {

                var product = con.Rooms.Find(id);
       
                var IdRoom = Session["id"];
                var IdHotel = con.Rooms.Where(r => r.IdRoom == id).FirstOrDefault().IdHotel;
                var IdCity = con.Hotels.Where(r => r.IdHotel == IdHotel).FirstOrDefault().IdCity;

                var NameHotel = con.Hotels.Where(h => h.IdHotel == IdHotel).FirstOrDefault().HotelName;
                var HotelAddress = con.Hotels.Where(h => h.IdHotel == IdHotel).FirstOrDefault().HotelAddress;

                var Evaluate = con.Hotels.Where(h => h.IdHotel == IdHotel).FirstOrDefault().Evaluate;
                var CoverImage = con.Hotels.Where(h => h.IdHotel == IdHotel).FirstOrDefault().CoverImage;

                var RoomName = con.Rooms.Where(r => r.IdRoom == id).FirstOrDefault().RoomName;
                var RoomService = con.Rooms.Where(r => r.IdRoom == id).FirstOrDefault().RoomService;

                var RoomInformation = con.Rooms.Where(r => r.IdRoom == id).FirstOrDefault().RoomInformation;
                var MaxPerson = con.Rooms.Where(r => r.IdRoom == id).FirstOrDefault().MaxPerson;

                var Price = con.Rooms.Where(r => r.IdRoom == id).FirstOrDefault().Price;
                var srcImageHotel = "/DataBase/images/hotels";

                if (IdCity == 1)
                {
                    srcImageHotel += "/hanoi";
                }
                if (IdCity == 2)
                {
                    srcImageHotel += "/danang";
                }
                if (IdCity == 3)
                {
                    srcImageHotel += "/vungtau";
                }
                if (IdCity == 4)
                {
                    srcImageHotel += "/nhatrang";
                }
                if (IdCity == 5)
                {
                    srcImageHotel += "/phuquoc";
                }
                if (IdCity == 6)
                {
                    srcImageHotel += "/halong";
                }
                if (IdCity == 7)
                {
                    srcImageHotel += "/hochiminh";
                }
                if (IdCity == 8)
                {
                    srcImageHotel += "/haiphong";
                }
                if (IdCity == 9)
                {
                    srcImageHotel += "/dalat";
                }
                if (IdCity == 10)
                {
                    srcImageHotel += "/hoian";
                }
                TempData["IdRoom"] = id;
                TempData["SourceImageHotel"] = srcImageHotel;
                TempData["IdHotel"] = IdHotel;
                Session["IdHotel"] = IdHotel;
                TempData["NameHotel"] = NameHotel;
                TempData["CoverImage"] = CoverImage + ".jpg";
                TempData["HotelAddress"] = HotelAddress;
                TempData["Evaluate"] = Evaluate;
                TempData["RoomName"] = RoomName;
                TempData["RoomService"] = RoomService.Split(',');
                TempData["RoomInformation"] = RoomInformation.Split(',');
                TempData["MaxPerson"] = MaxPerson;
                TempData["Price"] = Price;
                TempData["Vat"] = Price / 10;
                TempData["Total"] = Price + Price / 10;
                Session["IdRoom"] = id;
                return RedirectToAction("Index");
            }
        }

        public ActionResult BookingSucces()
        {

            var Username = Session["Username"];
            string user = Username.ToString();
            var Email = con.Accounts.Where(r => r.Username == user).FirstOrDefault().Email;
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Web đặt phòng khách sạn", "webdatphongkhachsandhlt@gmail.com"));

            message.To.Add(new MailboxAddress("Xac nhan dang ki dat phong khac san", Email));
            Random rd = new Random();
            var ramdom = rd.Next(10000, 90000);
            Session["ramdom"] = ramdom;
            message.Subject = "Mở file đính kèm và làm theo hướng dẫn";

            message.Body = new TextPart("plan")
            {
                Text = "Chào bạn , xin hãy chuyển khoản tiền cọc qua số stk 001200029525 vả nhập mã xác thực: " + ramdom
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("webdatphongkhachsandhlt@gmail.com", "DHLT123456qwer");
                client.Send(message);
                client.Disconnect(true);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Confirm()
        {
            var code = Request.Form["code"];
            if (code == Session["ramdom"].ToString())
            {
                var Username = Session["Username"];
                var IdHotel = Session["IdHotel"];
                var RoomAmount = Session["RoomAmount"];
                var RoomReserveTime = Session["RoomReserveTime"];
                var PaymentTime = Session["PaymentTime"];
                var IdRoom = Session["IdRoom"];
                var PeopleAmount = Session["PeopleAmount"];
                var TotalMoney = Session["TotalMoney"];
                BookingDetail b = new BookingDetail
                {
                    IdHotel = (int)IdHotel,
                    Username = Username.ToString(),
                    RoomReserveTime = DateTime.Parse(RoomReserveTime.ToString()),
                    PaymentTime = DateTime.Parse(PaymentTime.ToString()),
                    RoomAmount = Int32.Parse(RoomAmount.ToString()),
                    TotalMoney = Int32.Parse(TotalMoney.ToString()),
                    ListIdRoomSelected = IdRoom.ToString(),
                    PeopleAmount = (int)PeopleAmount,

                };
                HamDatPhong HamDP = new HamDatPhong();
                HamDP.Insert(b);
                ViewBag.success = "Thành công";


                return View("BookingSucces");
            }
            else
            {
                return View("BookingSucces");
            }


        }
        // POST

        [HttpPost]
        public ActionResult DatPhong()
        {
            var roomReserveTime = Request.Form["RoomReserveTime"];
            var paymentTime = Request.Form["PaymentTime"];
            var idroom = Session["IdRoom"];

            
            var check = con.Database.SqlQuery<int>("checktime1 {0}, {1}, {2}", new object[] { roomReserveTime, paymentTime, idroom }).FirstOrDefault();
            if (check == 0)
            {
                Session["RoomAmount"] = Request.Form["RoomAmount"];
                Session["RoomReserveTime"] = Request.Form["RoomReserveTime"];
                Session["PaymentTime"] = Request.Form["PaymentTime"];
                var Child = Request.Form["Child"];
                var Person = Request.Form["Person"];
                Session["PeopleAmount"] = Int32.Parse(Child) + Int32.Parse(Person);
                Session["TotalMoney"] = Request.Form["TotalMoney"];
                return Redirect("/Payment/BookingSucces");
            }
            else
            {
                TempData["Mes"] = "Ngày này đã có người khác đặt vui lòng chọn ngày khác";
               
                return Redirect("/Payment/AddItem/" + idroom);
            }
           

        }
        public ActionResult HistoryBooking()
        {
            var user = Session["Username"];
            string userr = user.ToString();
            var b = con.BookingDetails.Where(i => i.Username == userr).ToList();
            return View(b);
        }
    }
}