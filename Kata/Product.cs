using System;
using System.Collections.Generic;
using System.Text;

enum precedence
{
    after,
    before
}

namespace Kata
{
    class Product
    {
        public string Name { get; set; }
        public int UPC { get; set; }
        public double Price { get; set; }

        public Product(string name, int upc, double price)
        {
            Price = price;
            Name = name;
            UPC = upc;
       
        }


    }
}
