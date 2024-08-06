using System;
using System.Data.SqlClient;

namespace dotnet_framework_mvc_animals.DataAccesLayer.Connection
{
    public class DatabaseConnection
    {
        private SqlConnection sqlConnection;

        public SqlConnection SqlConnection { get => sqlConnection; }

        public DatabaseConnection()
        {
            try
            {
                string connectionString = "Data Source=200.234.224.123,54321;" +
                                          "Initial Catalog=JayMarcAnimal;" +
                                          "User ID=sa;" +
                                          "Password=Sql#123456789;";

                this.sqlConnection = new SqlConnection(connectionString);
            }
            catch (SqlException ex)
            {
                // Manejar cualquier otra excepción
                Console.WriteLine($"General Error: {ex.Message}");
            }
        }
    }
}