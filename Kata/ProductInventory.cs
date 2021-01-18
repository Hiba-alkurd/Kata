using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    class ProductInventory
    {
        Dictionary<int, Product> products;
        Dictionary<int, UPCDiscount> UPCdiscounts;
        UniversalDiscount universalDiscount;

        public double TaxRate { get; set; } = 0.2;


        public ProductInventory()
        {
            products = new Dictionary<int, Product>();
            UPCdiscounts = new Dictionary<int, UPCDiscount>();
            universalDiscount = new UniversalDiscount(0.0, precedence.after);
        }

        public void AddUniDiscount(int discount, precedence type)
        {
            universalDiscount.Discount = (double)discount /100;
            universalDiscount.Type = type;
        }
        public void AddUPCDiscount(int discount, precedence type, int upc)
        {
            if (UPCdiscounts.ContainsKey(upc))
            {
                Console.WriteLine($"UPC Discount for product {upc} already exists.");
                return;
            }
            UPCdiscounts.Add(upc, new UPCDiscount((double)discount/100, type));
        }

        public void AddProduct(string name, int upc, double price)
        {
            products.Add(upc, new Product(name, upc, price));
        }

        public Product GetProduct(int upc)
        {
            return products[upc];
        }

 

        public double CalculatePriceWithTax(int upc)
        {
            return GetProduct(upc).Price * TaxRate + GetProduct(upc).Price;
        }

        public double CalculateTax(double price)
        {
            return TaxRate * price;
        }

        public double CalculatePriceWithDiscount(int upc)
        {
            IDiscount UPCDiscount = null;
            if (UPCdiscounts.ContainsKey(upc))
            {
                UPCDiscount = UPCdiscounts[upc];
            }

            double price = GetProduct(upc).Price;
            price -= CalculatePriceBeforeDiscount(price, UPCDiscount);
            double tax = CalculateTax(price);
            price -= CalculatePriceAfterDiscount(price, UPCDiscount);
            price += tax;
            return Math.Round(price , 2);
        }

        double CalculatePriceBeforeDiscount(double price, IDiscount UPCDiscount)
        {
            double discount = 0.0;
            discount += universalDiscount.GetBeforeDiscountedPrice(price);
            discount += UPCDiscount == null ? 0.0 : UPCDiscount.GetBeforeDiscountedPrice(price);
            return discount;
        }
        double CalculatePriceAfterDiscount(double price, IDiscount UPCDiscount)
        {
            double discount = 0.0;
            discount += universalDiscount.GetAfterDiscountedPrice(price);
            discount += UPCDiscount == null ? 0.0 : UPCDiscount.GetAfterDiscountedPrice(price);
            return discount;
        }

        public void Report(int upc)
        {
            Console.WriteLine(CalculatePriceWithDiscount(upc) );
        }

    }
}
