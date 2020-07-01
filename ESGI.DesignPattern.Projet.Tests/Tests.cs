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
            var repository = new MockReceiptRepository();
            
            var checkout = new CheckoutBuilder()
                .WithRepository(repository)
                .Build();
            
            var money = new MoneyBuilder()
                .WithValue(150)
                .Build();

            var receipt = checkout.CreateReceipt(money);
            Assert.True(repository._receipts.Count == 1);
        }
        
        [Fact]
        public void ReceiptRepositoryBuilder_Should_Throw_Exception_With_Out_Env()
        {
            var ex = Assert.Throws<Exception>(() => new ReceiptRepositoryBuilder().Build());
            Assert.Equal("Environment variables may not have been set",ex.Message);
        }
        
        [Fact]
        public void ReceiptRepositoryBuilder_Should_Throw_Exception_With_Env()
        {
            Environment.SetEnvironmentVariable("DATABASE_NAME","projet");
            Environment.SetEnvironmentVariable("DATABASE_USER","root");
            Environment.SetEnvironmentVariable("DATABASE_PASSWORD","mot2passe");
            var ex = Assert.Throws<Exception>(() => new ReceiptRepositoryBuilder().Build());
            Assert.Equal("Can't connect to database",ex.Message);
        }
    }
}