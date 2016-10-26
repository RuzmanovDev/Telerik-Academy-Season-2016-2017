using System;
using System.Data.SqlClient;

namespace PrintNumberOfCategories
{
    public class PrintNumberOfCategories
    {
        static void Main(string[] args)
        {
            string connecionString = "Server = .; Database = NORTHWND; Integrated Security=true";


            var connection = new SqlConnection(connecionString);
            connection.Open();
            using (connection)
            {
                var command = new SqlCommand("SELECT COUNT(*) FROM Categories", connection);
                int categoriesCount = (int)command.ExecuteScalar();

                Console.WriteLine($"Number of categoires: {categoriesCount}");
            }
        }
    }
}
