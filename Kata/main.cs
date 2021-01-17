using System;

namespace Kata
{
    class main
    {

        static void Main(string[] args)
        {
            var product = new Product("The Little Prince", 12345, 20.25);
            product.DisplayPriceWithTax();
            product.DisplayPriceWithTax(0.21);
        }
    }
}
