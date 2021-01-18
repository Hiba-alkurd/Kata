using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    
    class ProductInventory
    {
        Dictionary<int, Product> products;
        Dictionary<int, UPCDiscount> UPCdiscounts;
        Dictionary<ExpensesTypes, Expense> Expenses;
        UniversalDiscount universalDiscount;
        DiscountManager discountManager;

        public double TaxRate { get; set; } = 0.2;


        public ProductInventory()
        {
            products = new Dictionary<int, Product>();
            UPCdiscounts = new Dictionary<int, UPCDiscount>();
            universalDiscount = new UniversalDiscount(0.0, precedence.after);
            Expenses = new Dictionary<ExpensesTypes, Expense>();
            discountManager = new DiscountManager();
        }

        public void AddUniDiscount(int discount, precedence type)
        {
            universalDiscount.Amount = (double)discount /100;
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

        public void AddExpenses(ExpensesTypes type, MoneyRepresentation moneyRep,double amount)
        {
            Expenses.Add(type, new Expense(moneyRep, amount));
        }
        
        public void SetDicountCalculation(CalculationTypes calculation)
        {
            discountManager.calculationTypes = calculation;
        }

        public double CalculateTax(double price, Discount upc)
        {
            price -= discountManager.CalculateDiscountBeforeTax(price, upc, universalDiscount);
            return TaxRate * price;
        }

        public void Report(int upc)
        {
            var tem = GetProduct(upc);
            UPCDiscount UPCDiscount = null;
            if (UPCdiscounts.ContainsKey(upc))
            {
                UPCDiscount = UPCdiscounts[upc];
            }

            Console.WriteLine($"Cost = ${Math.Round(tem.Price, 2)}");

            double tax = Math.Round(CalculateTax(tem.Price, UPCDiscount), 2);
            Console.WriteLine($"Tax = ${tax}");

            double discounts = Math.Round(discountManager.CalculateDiscount(tem.Price, UPCDiscount, universalDiscount), 2) ;
            if (discounts != 0) Console.WriteLine($"Discounts = ${discounts}");

            double total = tem.Price - discounts + tax;
            double expenseValue = 0.0;
            
            foreach (var expense in Expenses)
            {
                if (expense.Value.MoneyRep == MoneyRepresentation.Absolute)
                {
                    expenseValue = Math.Round(expense.Value.Amount, 2);
                }
                else
                {
                    expenseValue = Math.Round(tem.Price * (expense.Value.Amount / 100), 2);
                }
                total += expenseValue;
                Console.WriteLine($"{expense.Key} = ${expenseValue}");
            }

            Console.WriteLine($"TOTAL = ${Math.Round(total, 2)}");


        }

    }
}
