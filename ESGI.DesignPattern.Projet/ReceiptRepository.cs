using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ESGI.DesignPattern.Projet
{
    public class ReceiptRepository: IRepository
    {
        private readonly MySqlConnection _databaseConnection;
        public ReceiptRepository()
        {
            _databaseConnection = DatabaseConnection.GetInstance();
        }
        
        public void Store(Receipt receipt)
        {
            try
            {
                var command = new MySqlCommand("insert into RECEIPT (AMOUNT, TAX, TOTAL)"
                                               + "values(@amount, @tax, @total);", _databaseConnection);
                command.Parameters.AddWithValue("@amount", receipt.Amount.AsDecimal());
                command.Parameters.AddWithValue("@tax", receipt.Tax.AsDecimal());
                command.Parameters.AddWithValue("@total", receipt.Total.AsDecimal());
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Can't save the receipt !");
            }
            
        }
    }
}