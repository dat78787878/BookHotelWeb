using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace BookHotelWeb.Entity
{
    public class Common
    {
        public static string FormatMoney(string money)
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            var m = double.Parse(money).ToString("#,###", cul.NumberFormat);
            return m;
        }

        /// <summary>
        /// Tính tổng trung bình giá của 1 khách sạn
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int GetRoomAveragePrice(List<int> a)
        {
            var price = 0;
            for (int i = 0; i < a.Count(); i++)
            {
                price += a[i];
            }
            return (int)price / a.Count();
        }


    }
}