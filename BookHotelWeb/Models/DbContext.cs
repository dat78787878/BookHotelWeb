using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BookHotelWeb.Models
{
    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<BookingDetail> BookingDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.BookingDetails)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<City>()
                .Property(e => e.CityImage)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Hotels)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Comment>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Hotel>()
                .Property(e => e.Evaluate)
                .IsUnicode(false);

            modelBuilder.Entity<Hotel>()
                .Property(e => e.Distance)
                .IsUnicode(false);

            modelBuilder.Entity<Hotel>()
                .Property(e => e.CoverImage)
                .IsUnicode(false);

            modelBuilder.Entity<Hotel>()
                .Property(e => e.Image1)
                .IsUnicode(false);

            modelBuilder.Entity<Hotel>()
                .Property(e => e.Image2)
                .IsUnicode(false);

            modelBuilder.Entity<Hotel>()
                .Property(e => e.Image3)
                .IsUnicode(false);

            modelBuilder.Entity<Hotel>()
                .Property(e => e.Image4)
                .IsUnicode(false);

            modelBuilder.Entity<Hotel>()
                .Property(e => e.Image5)
                .IsUnicode(false);

            modelBuilder.Entity<Hotel>()
                .Property(e => e.Image6)
                .IsUnicode(false);

            modelBuilder.Entity<Hotel>()
                .Property(e => e.Image7)
                .IsUnicode(false);

            modelBuilder.Entity<Hotel>()
                .Property(e => e.Image8)
                .IsUnicode(false);

            modelBuilder.Entity<Hotel>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.Hotel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hotel>()
                .HasMany(e => e.BookingDetails)
                .WithRequired(e => e.Hotel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BookingDetail>()
                .Property(e => e.Username)
                .IsUnicode(false);

         
            modelBuilder.Entity<BookingDetail>()
                .Property(e => e.ListIdRoomSelected)
                .IsUnicode(false);
        }
    }
}
