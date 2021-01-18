using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    class Expense
    {
        public MoneyRepresentation MoneyRep { get; }
        public double Amount { get; set; }

        public Expense(MoneyRepresentation moneyRep, double amount)
        {
            MoneyRep = moneyRep;
            Amount = amount;
        }

        
    }
}
