using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    class ProductInventory
    {
        Dictionary<int, Product> products;

        public ProductInventory()
        {
            products = new Dictionary<int, Product>();
        }

        public void AddProduct(string name, int upc, double price)
        {
            products.Add(upc, new Product(name, upc, price));
        }

        public Product GetProduct(int upc)
        {
            return products[upc];
        }
    }
}
