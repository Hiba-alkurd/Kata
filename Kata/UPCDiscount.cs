using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    class UPCDiscount : Discount
    {
        public UPCDiscount(double discount, precedence type) : base(discount, type)
        {
        }
    }
}
