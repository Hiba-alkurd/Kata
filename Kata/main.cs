using System;

namespace Kata
{
    class main
    {

        static void Main(string[] args)
        {
            var inventory = new ProductInventory();
            inventory.AddProduct("The Little Prince", 12345, 20.25);
            inventory.AddUniDiscount(15, precedence.after);
            inventory.AddUPCDiscount(7, precedence.before, 12345);
            inventory.Report(12345);
        }
    }
}
