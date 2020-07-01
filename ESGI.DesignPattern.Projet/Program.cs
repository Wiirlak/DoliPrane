using System;

namespace ESGI.DesignPattern.Projet
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new ReceiptRepositoryBuilder().Build();
            
            var checkout = new CheckoutBuilder()
                .WithRepository(repository)
                .Build();
            
            var money = new MoneyBuilder()
                .WithValue(150)
                .Build();

            var receipt = checkout.CreateReceipt(money);
            foreach (var i in receipt.Format())
            {
                Console.WriteLine(i);
            }
        }
    }
}