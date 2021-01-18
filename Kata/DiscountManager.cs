using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    class DiscountManager
    {
        public CalculationTypes calculationTypes { get; set; }
        public double CAP { get; set; } = 10000;
        public MoneyRepresentation CAPrep { get; set; }
        public DiscountManager(CalculationTypes calculationTypes = CalculationTypes.Addition)
        {
            this.calculationTypes = calculationTypes;
        }

        public double CalculateCAP(double price)
        {
            if (CAPrep == MoneyRepresentation.Percentage)
            {
                return (CAP / 100) * price;
            }
            else
            {
                return CAP;
            }
             
        }
        public double CalculateDiscount(double p, UPCDiscount UPCDiscount, Discount universalDiscount)
        {
            double price = p;
            double discount = CalculateDiscountBeforeTax(price, UPCDiscount, universalDiscount);
            price -= discount;
            discount += CalculateDiscountAfterTax(price, UPCDiscount, universalDiscount);
            double CAPvalue = CalculateCAP(p);
            return discount > CAPvalue ? CAPvalue : discount;
        }

        public double CalculateDiscountBeforeTax(double price, Discount UPCDiscount, Discount universalDiscount)
        {
            double discount = 0.0;
            if (this.calculationTypes == CalculationTypes.Addition)
            {
                discount += universalDiscount.GetBeforeDiscountedPrice(price);
                discount += UPCDiscount == null ? 0.0 : UPCDiscount.GetBeforeDiscountedPrice(price);
               
            }
            else
            {
                discount += universalDiscount.GetBeforeDiscountedPrice(price);
                discount += UPCDiscount == null ? 0.0 : UPCDiscount.GetBeforeDiscountedPrice(price-discount);
                
            }

            return discount;
        }
        public double CalculateDiscountAfterTax(double price, Discount UPCDiscount, Discount universalDiscount)
        {
            double discount = 0.0;
            if (this.calculationTypes == CalculationTypes.Addition)
            {
                discount += universalDiscount.GetAfterDiscountedPrice(price);
                discount += UPCDiscount == null ? 0.0 : UPCDiscount.GetAfterDiscountedPrice(price);

            }
            else
            {
                discount += universalDiscount.GetAfterDiscountedPrice(price);
                discount += UPCDiscount == null ? 0.0 : UPCDiscount.GetAfterDiscountedPrice(price - discount);

            }
            return discount;
        }

    }
}
