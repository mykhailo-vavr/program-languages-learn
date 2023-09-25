using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Hotel
{
    public class Hotel
    {
        private string id, checkinDatetime, checkoutDatetime, bookingNumber, guestName, city;
        private double price;

        public Hotel InputProduct()
        {
            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(this))
            {
                if (prop.Name != "id")
                {
                    Console.Write($"{prop.Name}: ");
                    prop.SetValue(this, Convert.ChangeType(Console.ReadLine(), prop.PropertyType));
                }
                id = Guid.NewGuid().ToString();
            }
            return this;
        }

        public string Id { get; set; }

        public string CheckinDateTime { get; set; }

        public string CheckoutDatetime { get; set; }

        public string BookingNumber { get; set; }

        public string GuestName { get; set; }

        public string City { get; set; }

        public double Price { get; set; }

        public override string ToString()
        {
            string res = "";
            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(this))
                res += ($"{prop.Name}: {prop.GetValue(this)}\n");
            return res.Substring(0, res.Length - 1);
        }
    }
}