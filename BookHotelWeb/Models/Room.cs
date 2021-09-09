namespace BookHotelWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Room")]
    public partial class Room
    {
        [Key]
        public int IdRoom { get; set; }

        [StringLength(50)]
        public string RoomName { get; set; }

        public int? Price { get; set; }

        [StringLength(4000)]
        public string RoomService { get; set; }

        public bool? IsCheck { get; set; }

        [StringLength(4000)]
        public string RoomInformation { get; set; }

        [StringLength(4000)]
        public string RoomIntroduce { get; set; }

        public int? IdHotel { get; set; }

        public int? MaxPerson { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
