using System;
using MySql.Data.MySqlClient;


namespace ESGI.DesignPattern.Projet
{
    public static class DatabaseConnection
    {
        private static MySqlConnection databaseConnection = null;
        private static readonly string DatabaseName = Environment.GetEnvironmentVariable("DATABASE_NAME");
        private static readonly string User = Environment.GetEnvironmentVariable("DATABASE_USER");
        private static readonly string Pass = Environment.GetEnvironmentVariable("DATABASE_PASSWORD");

        static DatabaseConnection()
        {
            if (DatabaseName == null || User == null || Pass == null)
            {
                Console.WriteLine("Error 32: Environment variables may not have been set");
                return;
            }

            try
            {
                using (databaseConnection = new MySqlConnection
                {
                    ConnectionString = $"Database={DatabaseName};Data Source=localhost;User Id={User};Password={Pass}"
                })
                {
                    databaseConnection.Open();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error 51: Can't connect to database");
                databaseConnection = null;
            }
        }

        public static MySqlConnection GetInstance()
        {
            return databaseConnection;
        }
    }
}