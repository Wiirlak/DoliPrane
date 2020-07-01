using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;
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
        public void CheckoutShouldBeStored()
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
        public void ReceiptRepositoryBuilderShouldThrowExceptionWithOutEnv()
        {
            var ex = Assert.Throws<Exception>(() => new ReceiptRepositoryBuilder().Build());
            Assert.Equal("Environment variables may not have been set",ex.Message);
        }
        
        [Fact]
        public void ReceiptRepositoryBuilderShouldThrowExceptionWithEnv()
        {
            Environment.SetEnvironmentVariable("DATABASE_NAME","projet");
            Environment.SetEnvironmentVariable("DATABASE_USER","root");
            Environment.SetEnvironmentVariable("DATABASE_PASSWORD","mot2passe");
            var ex = Assert.Throws<Exception>(() => new ReceiptRepositoryBuilder().Build());
            Assert.Equal("Can't connect to database",ex.Message);
        }
        
        [Fact]
        public void MoneyBuilderShouldGenerateTheRightAmount()
        {
            var money = new MoneyBuilder().WithValue(1000).Build();
            Assert.Equal("1000,00", money.Format());
        }

        [Fact]
        public void MoneyBuilderShouldWithDecimal()
        {
            var money = new MoneyBuilder().WithValue(new decimal(214.2)).Build();
            Assert.Equal("214,20", money.Format());
        }


        [Fact]
        public void MoneyBuilderShouldGetTheRightPercentage()
        {
            var money = new MoneyBuilder().WithValue(3).Build();
            var perc = money.Percentage(9);
            Assert.Equal("0,27", perc.Format());
        }

        [Fact]
        public void MoneyBuilderShouldBeCorrectlyAdded()
        {
            var lparam = new MoneyBuilder().WithValue(17).Build();
            var rparam = new MoneyBuilder().WithValue(183).Build();
            var add = lparam.Add(rparam);
            Assert.Equal("200,00", add.Format());
        }
    }
}