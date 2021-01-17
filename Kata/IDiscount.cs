using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    interface IDiscount
    {
        void CalculatePriceWithDiscount(double price, double tax);
    }
}
