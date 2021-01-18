using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    interface IDiscount
    {
        double GetDiscount(double price, double discount);
        double GetBeforeDiscountedPrice(double price);
        double GetAfterDiscountedPrice(double price);
    }
}
