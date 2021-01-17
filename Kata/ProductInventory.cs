using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    class ProductInventory
    {
        Dictionary<int, Product> products;
        public double UniversalDiscount { get; set; }


        public ProductInventory(double universalDiscount)
        {
            products = new Dictionary<int, Product>();
            UniversalDiscount = universalDiscount;
        }

        public void AddProduct(string name, int upc, double price)
        {
            products.Add(upc, new Product(name, upc, price, UniversalDiscount));
        }

        public Product GetProduct(int upc)
        {
            return products[upc];
        }


    }
}
