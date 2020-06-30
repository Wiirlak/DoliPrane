using System;
using System.Collections.Generic;
using System.Text;

namespace ESGI.DesignPattern.Projet
{
    public class Checkout
    {
        public Receipt CreateReceipt(Money amount)
        {
            var vat = amount.Percentage(20);

            var receipt = new ReceiptBuilder()
                .WithAmount(amount)
                .WithTax(vat)
                .WithTotal(amount.Add(vat))
                .Build();

            ReceiptRepository.Store(receipt);

            return receipt;
        }
    }
}