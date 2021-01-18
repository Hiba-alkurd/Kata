using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
     class UniversalDiscount : Discount
    {
        public UniversalDiscount(double discount, precedence type) : base(discount, type)
        {
        }
    }
}
