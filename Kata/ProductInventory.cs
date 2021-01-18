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
        private double taxRate = 0.2;
        public double GetTaxRate()
        {
            return taxRate;
        }
        public void SetTaxRate(double value)
        {
            taxRate = value / 100;
        }

        public Money Currency { get; set; } = Money.USD;

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

        public void AddCAP(double amount, MoneyRepresentation rep)
        {
            discountManager.CAP = amount;
            discountManager.CAPrep = rep;
        }

        public double CalculateTax(double price, Discount upc)
        {
            price -= discountManager.CalculateDiscountBeforeTax(price, upc, universalDiscount);
            return GetTaxRate() * price;
        }

        public void Report(int upc)
        {
            var tem = GetProduct(upc);
            UPCDiscount UPCDiscount = null;
            if (UPCdiscounts.ContainsKey(upc))
            {
                UPCDiscount = UPCdiscounts[upc];
            }

            Console.WriteLine($"Cost = {RoundToString(tem.Price)} {Currency}");

            double tax = CalculateTax(tem.Price, UPCDiscount);
            Console.WriteLine($"Tax = {RoundToString(tax)} {Currency}");

            double discounts = discountManager.CalculateDiscount(tem.Price, UPCDiscount, universalDiscount) ;
            if (discounts != 0) Console.WriteLine($"Discounts = {RoundToString(discounts)} {Currency}");

            double total = tem.Price - discounts + tax;
            double expenseValue = 0.0;
            
            foreach (var expense in Expenses)
            {
                if (expense.Value.MoneyRep == MoneyRepresentation.Absolute)
                {
                    expenseValue = expense.Value.Amount;
                }
                else
                {
                    expenseValue = tem.Price * (expense.Value.Amount / 100);
                }
                total += expenseValue;
                Console.WriteLine($"{expense.Key} = {RoundToString(expenseValue)} {Currency}");
            }

            Console.WriteLine($"TOTAL = {RoundToString(total)} {Currency}");


        }
        string RoundToString(double Num)
        {
            return Math.Round(Num, 2).ToString();
        }

    }
}
