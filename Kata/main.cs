using System;

namespace Kata
{
    class main
    {

        static void Main(string[] args)
        {
            var inventory = new ProductInventory();
            inventory.SetTaxRate(21);
            inventory.AddProduct("The Little Prince", 12345, 20.25);
            inventory.AddUniDiscount(15, precedence.after);
            inventory.AddUPCDiscount(7, precedence.after, 12345);
            inventory.SetDicountCalculation(CalculationTypes.Addition);
            inventory.AddCAP(30, MoneyRepresentation.Percentage);
            inventory.Report(12345);
        }
    }
}
