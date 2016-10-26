using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace ExcelReader
{
    public class ExcelOperations
    {
        static void Main(string[] args)
        {
            ReadExcelFile();
            WriteToFile("Petkancho", "500");
            ReadExcelFile();
        }

        private static string GetConnectionString()
        {
            Dictionary<string, string> props = new Dictionary<string, string>();

            // XLSX - Excel 2007, 2010, 2012, 2013
            props["Provider"] = "Microsoft.ACE.OLEDB.12.0;";
            props["Extended Properties"] = "Excel 12.0 XML";
            props["Data Source"] = "..//..//data.xlsx";

            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, string> prop in props)
            {
                sb.Append(prop.Key);
                sb.Append('=');
                sb.Append(prop.Value);
                sb.Append(';');
            }

            return sb.ToString();
        }

        private static void ReadExcelFile()
        {
            string connectionString = GetConnectionString();

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                OleDbCommand command = new OleDbCommand("SELECT * FROM [Sheet1$]", conn);
                using (OleDbDataReader dataReader = command.ExecuteReader())
                {
                    var columnNames = dataReader.GetSchemaTable();
                    Console.WriteLine(" {0}", new string('-', 25));
                    Console.WriteLine("| {0} | {1} |", columnNames.Rows[0]["ColumnName"].ToString().PadRight(15), columnNames.Rows[1]["ColumnName"]);
                    Console.WriteLine(" {0}", new string('-', 25));

                    while (dataReader.Read())
                    {
                        var name = dataReader[0].ToString();
                        var score = dataReader[1].ToString();
                        Console.WriteLine("| {0} | {1} |", name.PadRight(15), score.PadRight(5));
                    }
                    Console.WriteLine(" {0}", new string('-', 25));
                }
                conn.Close();
            }
        }

        private static void WriteToFile(string name, string score)
        {
            string con = GetConnectionString();
            using (OleDbConnection connection = new OleDbConnection(con))
            {
                connection.Open();

                OleDbCommand cmd = new OleDbCommand("INSERT INTO [Sheet1$] ([Name],[Score]) VALUES (@name, @score)", connection);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@score", score);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
