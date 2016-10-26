using System.Data;
using System.Data.SqlClient;

namespace AddNewProduct
{
    public class AddNewProduct
    {
        static void Main(string[] args)
        {
            string connecionString = "Server = .; Database = NORTHWND; Integrated Security=true";

            var connection = new SqlConnection(connecionString);
            connection.Open();

            using (connection)
            {
                var queryString = "INSERT INTO PRODUCTS(ProductName) VALUES(@ProductName)";

                var command = new SqlCommand(queryString, connection);
                var productParam = new SqlParameter("ProductName", SqlDbType.NVarChar);

                productParam.Value = "Test";
                command.Parameters.Add(productParam);

                command.ExecuteNonQuery();
            }
        }
    }
}
