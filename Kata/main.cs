using System;

namespace Kata
{
    class main
    {

        static void Main(string[] args)
        {
            var inventory = new ProductInventory(0.15);
            inventory.AddProduct("The Little Prince", 12345, 20.25);
            var product = inventory.GetProduct(12345);
            product.UPCdiscount = 0.07;
            product.CalculatePriceAfterDiscount();
        }
    }
}
