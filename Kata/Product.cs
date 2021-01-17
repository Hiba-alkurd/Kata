using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    class Product
    {
        public string Name { get; set; }
        public int UPC { get; set; }
        public double TaxRate { get; set; }
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
            Console.WriteLine($"Product price reported as ${_price} before tax and ${CalculatePriceWithTax(tax)} after {tax*100}% tax");
        }


    }
}
