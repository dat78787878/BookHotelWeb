namespace BookHotelWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("BookingDetail")]
    public partial class BookingDetail
    {
        [Key]
        public int IdBookingDetail { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        public int? IdHotel { get; set; }

        [Column(TypeName = "date")]
        public DateTime? RoomReserveTime { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PaymentTime { get; set; }

        public int? PeopleAmount { get; set; }

        public int? RoomAmount { get; set; }

        public int? TotalMoney { get; set; }

        public int? ListIdRoomSelected { get; set; }

        public virtual Account Account { get; set; }

        public virtual Room Room { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
    public class HamDatPhong
    {
        private DBContext db;

        public HamDatPhong()
        {
            db = new DBContext();
        }

        public IQueryable<BookingDetail> BookingDetail
        {
            get { return db.BookingDetails; }
        }

        public string Insert(BookingDetail model)
        {
            db.BookingDetails.Add(model);
            db.SaveChanges();
            return model.ListIdRoomSelected;
        }

    }
}
