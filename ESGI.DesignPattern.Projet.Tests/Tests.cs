using System;
using System.Collections.Generic;
using Xunit;

namespace ESGI.DesignPattern.Projet.Tests
{
    public class MockReceiptRepository: IRepository
    {
        public List<Receipt> _receipts { get; } = new List<Receipt>();
        public void Store(Receipt receipt)
        {
            _receipts.Add(receipt);
        }
    }

    public class Tests
    {
        [Fact]
        public void Checkout()
        {
            ReceiptRepository repository = new ReceiptRepository();
            Checkout checkout = new Checkout(repository);
            Money money = new Money(150);

            Receipt receipt = checkout.CreateReceipt(money);
            Assert.NotNull(receipt);
        }
        
        [Fact]
        public void MockedCheckout()
        {
            MockReceiptRepository repository = new MockReceiptRepository();
            Checkout checkout = new Checkout(repository);
            Money money = new Money(150);

            Receipt receipt = checkout.CreateReceipt(money);
            Assert.True(repository._receipts.Count == 1);
        }
    }
}