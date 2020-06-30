using System;

namespace ESGI.DesignPattern.Projet
{
    class Program
    {
        static void Main(string[] args)
        {
            ReceiptRepository repository = new ReceiptRepository();
            Checkout checkout = new Checkout(repository);
            Money money = new Money(150);

            Receipt receipt = checkout.CreateReceipt(money);
            foreach (var i in receipt.Format())
            {
                Console.WriteLine(i);
            }
        }
    }
}