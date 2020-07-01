using System;
using MySql.Data.MySqlClient;


namespace ESGI.DesignPattern.Projet
{
    public static class DatabaseConnection
    {
        private static readonly MySqlConnection databaseConnection;
        private static readonly string DatabaseName = Environment.GetEnvironmentVariable("DATABASE_NAME");
        private static readonly string User = Environment.GetEnvironmentVariable("DATABASE_USER");
        private static readonly string Pass = Environment.GetEnvironmentVariable("DATABASE_PASSWORD");

        static DatabaseConnection()
        {
            if (DatabaseName == null || User == null || Pass == null)
            {
                throw new Exception("Environment variables may not have been set");
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
                throw new Exception("Can't connect to database");
            }
        }

        public static MySqlConnection GetInstance()
        {
            return databaseConnection;
        }
    }
}