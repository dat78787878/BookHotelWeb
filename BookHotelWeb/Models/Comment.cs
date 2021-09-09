namespace BookHotelWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        [StringLength(50)]
        public string Username { get; set; }

        [Column("Comment")]
        [StringLength(4000)]
        public string Comment1 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CommentDate { get; set; }

        public int IdHotel { get; set; }

        [Key]
        public int IdComment { get; set; }

        public virtual Account Account { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
