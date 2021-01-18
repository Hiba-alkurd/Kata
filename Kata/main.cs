using System;

namespace Kata
{
    class main
    {

        static void Main(string[] args)
        {
            var inventory = new ProductInventory();
            inventory.TaxRate = 0.21;
            inventory.AddProduct("The Little Prince", 12345, 20.25);
            inventory.AddUniDiscount(15, precedence.after);
            inventory.AddUPCDiscount(7, precedence.after, 12345);
            inventory.AddExpenses(ExpensesTypes.Packaging, MoneyRepresentation.Percentage, 1);
            inventory.AddExpenses(ExpensesTypes.Transport, MoneyRepresentation.Absolute, 2.2);
            inventory.SetDicountCalculation(CalculationTypes.Multiplication);
            inventory.Report(12345);
        }
    }
}
