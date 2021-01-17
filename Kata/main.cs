using System;

namespace Kata
{
    class main
    {

        static void Main(string[] args)
        {
            var inventory = new ProductInventory();
            inventory.AddProduct("The Little Prince", 12345, 20.25);
            var product = inventory.GetProduct(12345);
            product.CalculatePriceAfterDiscount(0.15);
        }
    }
}
