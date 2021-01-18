using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    class UniversalDiscount : IDiscount
    {
        public double Discount { get; set; }  = 0.0;
        public precedence Type { get; set; }

        public UniversalDiscount(double discount, precedence type)
        {
            Discount = discount;
            this.Type = type;
        }

        public double GetDiscount(double price, double discount)
        {
            return price * Discount;
        }

        public double GetBeforeDiscountedPrice(double price)
        {
            return this.Type == precedence.before? price * Discount : 0.0;
        }

        public double GetAfterDiscountedPrice(double price)
        {
            return this.Type == precedence.after ? price * Discount : 0.0;
        }
    }
}
