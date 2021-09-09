using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookHotelWeb.Models
{
    public class CartItem
    {
        public Room _booking_detail { get; set; }

    }
    //Thanh toan
    public class Payment
    {
        private List<CartItem> lineCollection = new List<CartItem>();
        public void AddItem(Room _booking)
        {
            CartItem line = lineCollection
               .Where(p => p._booking_detail.IdRoom == _booking.IdRoom)
               .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartItem
                {
                    _booking_detail = _booking
                });
            }
            else
            {
                lineCollection.Clear();
                lineCollection.Add(new CartItem
                {
                    _booking_detail = _booking
                });
            }
        }
        public IEnumerable<CartItem> Lines
        {
            get { return lineCollection; }
        }
    }
}