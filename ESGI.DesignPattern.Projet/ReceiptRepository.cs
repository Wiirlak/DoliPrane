using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ESGI.DesignPattern.Projet
{
    public class ReceiptRepository
    {
        public static void Store(Receipt receipt)
        {
            var databaseConnection = DatabaseConnection.GetInstance();
            if (databaseConnection == null)
            {
                Console.WriteLine("Error 64: Can't save to database");
                return;
            }

            var command = new MySqlCommand("insert into RECEIPT (AMOUNT, TAX, TOTAL)"
                                           + "values(@amount, @tax, @total);", databaseConnection);
            command.Parameters.AddWithValue("@amount", receipt.Amount.AsDecimal());
            command.Parameters.AddWithValue("@tax", receipt.Tax.AsDecimal());
            command.Parameters.AddWithValue("@total", receipt.Total.AsDecimal());
            command.Prepare();
            command.ExecuteNonQuery();
        }
    }
}