using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    class Product
    {
        public string Name { get; set; }
        public int UPC { get; set; }
        public double TaxRate { get; set; } = 0.2;
        private double _price;

        public Product(string name, int upc, double price )
        {
            _price = price;
            Name = name;
            UPC = upc;
       
        }

        public double CalculatePriceWithTax(double tax = 0.2)
        {
            return Math.Round(_price*tax+ _price, 2);
        }

        public void DisplayPriceWithTax(double tax = 0.2)
        {
            Console.WriteLine(CalculatePriceWithTax(tax));
        }
        public void DisplayPriceWithDiscount(double discount)
        {
            Console.WriteLine(CalculatePriceAfterDiscount(discount));
        }

        public double CalculateTax(double tax)
        {
            return Math.Round(_price * tax, 2);
        }

        public double CalculateDiscount(double discount)
        {
            return Math.Round(_price * discount, 2); 
        }

        public double CalculatePriceAfterDiscount(double discount)
        {
            var discountValue = CalculateDiscount(discount);
            var priceAfterDiscount = Math.Round(_price - discountValue + CalculateTax(TaxRate), 2);

            Console.WriteLine($"price {priceAfterDiscount}");
            Console.WriteLine($"discount {discountValue}");
            return priceAfterDiscount;

        }






    }
}
