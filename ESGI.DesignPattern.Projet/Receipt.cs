using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ESGI.DesignPattern.Projet
{
    public class Receipt
    {
        public Money Amount { get; }
        public Money Tax { get; }
        public Money Total { get; }

        public Receipt(Money amount, Money tax, Money total)
        {
            Amount = amount;
            Tax = tax;
            Total = total;
        }


        public IEnumerable<string> Format()
        {
            return new List<string>() { //
                    "Receipt", //
                    "=======", //
                    "Item 1 ... " + Amount.Format(), //
                    "Tax    ... " + Tax.Format(), //
                    "----------------", //
                    "Total  ... " + Total.Format() //
            };
        }
    }
}
