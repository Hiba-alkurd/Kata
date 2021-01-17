﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    class Product
    {
        public string Name { get; set; }
        public int UPC { get; set; }
        public double TaxRate { get; set; } = 0.2;
        public double Discount { get; set; } = 0.0;
        private double _price;

        public Product(string name, int upc, double price )
        {
            _price = price;
            Name = name;
            UPC = upc;
       
        }

        public double CalculatePriceWithTax()
        {
            return Math.Round(_price* TaxRate + _price, 2);
        }

        public double CalculateTax()
        {
            return Math.Round(_price * TaxRate, 2);
        }

        public double CalculateDiscount(double discount)
        {
            return Math.Round(_price * discount, 2); 
        }

        public double CalculatePriceAfterDiscount()
        {
            var discountValue = CalculateDiscount(Discount);
            var priceAfterDiscount = Math.Round(_price - discountValue + CalculateTax(), 2);

            Console.WriteLine($"price {priceAfterDiscount}");
            Console.WriteLine($"discount {discountValue}");

            return priceAfterDiscount;

        }
        public void DisplayPriceWithTax()
        {
            Console.WriteLine(CalculatePriceWithTax());
        }
        public void DisplayPriceWithDiscount(double discount)
        {
            Console.WriteLine(CalculatePriceAfterDiscount());
        }







    }
}
