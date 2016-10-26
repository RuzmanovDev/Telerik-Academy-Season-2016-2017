using System;
using System.Data.SqlClient;

namespace ConsoleClient
{
    public class PrintProductNameAndCategory
    {
        static void Main()
        {
            string connecionString = "Server = .; Database = NORTHWND; Integrated Security=true";

            var connection = new SqlConnection(connecionString);
            connection.Open();

            using (connection)
            {
                var command = new SqlCommand("SELECT c.CategoryName,p.ProductName FROM Products p JOIN Categories c ON p.CategoryID = c.CategoryID", connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string categoryName = (string)reader["CategoryName"];
                    string productName = (string)reader["ProductName"];


                    Console.WriteLine($"Category name: {categoryName}");
                    Console.WriteLine($"Product: {productName}");
                    Console.WriteLine("------------------");
                }

            }
        }
    }
}
