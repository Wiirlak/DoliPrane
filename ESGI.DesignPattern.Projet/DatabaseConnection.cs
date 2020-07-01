using System;
using MySql.Data.MySqlClient;


namespace ESGI.DesignPattern.Projet
{
    public static class DatabaseConnection
    {
        private static MySqlConnection _databaseConnection;
        private static string _databaseName; 
        private static string _user;
        private static string _pass;
        public static MySqlConnection GetInstance()
        {
            if(_databaseConnection == null)
                Initialize();
            return _databaseConnection;
        }

        private static void Initialize()
        {
            _databaseName = Environment.GetEnvironmentVariable("DATABASE_NAME");
            _user = Environment.GetEnvironmentVariable("DATABASE_USER");
            _pass = Environment.GetEnvironmentVariable("DATABASE_PASSWORD");
            if (_databaseName == null || _user == null || _pass == null)
            {
                throw new Exception("Environment variables may not have been set");
            }

            try
            {
                using (_databaseConnection = new MySqlConnection
                {
                    ConnectionString = $"Database={_databaseName};Data Source=localhost;User Id={_user};Password={_pass}"
                })
                {
                    _databaseConnection.Open();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Can't connect to database");
            }
        }
    }
}