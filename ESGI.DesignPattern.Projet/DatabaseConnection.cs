using System;
using MySql.Data.MySqlClient;


namespace ESGI.DesignPattern.Projet
{
    public static class DatabaseConnection
    {
        private static MySqlConnection databaseConnection;
        private static readonly string DatabaseName = Environment.GetEnvironmentVariable("DATABASE_NAME");
        private static readonly string User = Environment.GetEnvironmentVariable("DATABASE_USER");
        private static readonly string Pass = Environment.GetEnvironmentVariable("DATABASE_PASSWORD");
        
        static DatabaseConnection()
        {
            using (databaseConnection = new MySqlConnection
            {
                ConnectionString = $"Database={DatabaseName};Data Source=localhost;User Id={User};Password={Pass}"
            })
            {
                databaseConnection.Open();
            }
        }

        public static MySqlConnection GetInstance()
        {
            return databaseConnection;
        }
    }
}