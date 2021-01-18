using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    class Discount
    {
        public double Amount { get; set; } = 0.0;
        public precedence Type { get; set; }

        public Discount(double discount, precedence type)
        {
            Amount = discount;
            this.Type = type;
        }

        public double GetDiscount(double price, double discount)
        {
            return price * Amount;
        }
        public double GetBeforeDiscountedPrice(double price)
        {
            return this.Type == precedence.before ? price * Amount : 0.0;
        }

        public double GetAfterDiscountedPrice(double price)
        {
            return this.Type == precedence.after ? price * Amount : 0.0;
        }
    }
}
