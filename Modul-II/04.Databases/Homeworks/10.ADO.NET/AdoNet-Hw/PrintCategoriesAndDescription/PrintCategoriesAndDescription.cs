using System;
using System.Data.SqlClient;

namespace PrintCategoriesAndDescription
{
    public class PrintCategoriesAndDescription
    {
        static void Main(string[] args)
        {
            string connecionString = "Server = .; Database = NORTHWND; Integrated Security=true";

            var connection = new SqlConnection(connecionString);
            connection.Open();
            using (connection)
            {
                var command = new SqlCommand("SELECT CategoryName, Description FROM Categories", connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string categoryName = (string)reader["CategoryName"];
                    string description = (string)reader["Description"];

                    Console.WriteLine($"Category name: {categoryName}");
                    Console.WriteLine($"Description: {description}");
                    Console.WriteLine("------------------");
                }
            }
        }
    }
}
