namespace BookHotelWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hotel")]
    public partial class Hotel
    {
        private List<Hotel> lineCollection = new List<Hotel>();
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hotel()
        {
            Comments = new HashSet<Comment>();
            BookingDetails = new HashSet<BookingDetail>();
            Rooms = new HashSet<Room>();
        }

        [Key]
        public int IdHotel { get; set; }

        public int IdCity { get; set; }

        [StringLength(50)]
        public string HotelName { get; set; }

        [StringLength(50)]
        public string Evaluate { get; set; }

        [StringLength(50)]
        public string Distance { get; set; }

        [StringLength(500)]
        public string HotelAddress { get; set; }

        [StringLength(4000)]
        public string HotelIntroduce { get; set; }

        [StringLength(50)]
        public string CoverImage { get; set; }

        [StringLength(50)]
        public string Image1 { get; set; }

        [StringLength(50)]
        public string Image2 { get; set; }

        [StringLength(50)]
        public string Image3 { get; set; }

        [StringLength(50)]
        public string Image4 { get; set; }

        [StringLength(50)]
        public string Image5 { get; set; }

        [StringLength(50)]
        public string Image6 { get; set; }

        [StringLength(50)]
        public string Image7 { get; set; }

        [StringLength(50)]
        public string Image8 { get; set; }

        public virtual City City { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
