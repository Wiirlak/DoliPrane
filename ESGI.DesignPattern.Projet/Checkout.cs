using System;
using System.Collections.Generic;
using System.Text;

namespace ESGI.DesignPattern.Projet
{
    public class Checkout
    {
        private readonly IRepository _repository;
        
        public Checkout(IRepository repository)
        {
            _repository = repository;
        }

        public Receipt CreateReceipt(Money amount)
        {
            var vat = amount.Percentage(20);

            var receipt = new ReceiptBuilder()
                .WithAmount(amount)
                .WithTax(vat)
                .WithTotal(amount.Add(vat))
                .Build();

            _repository.Store(receipt);

            return receipt;
        }
    }
}