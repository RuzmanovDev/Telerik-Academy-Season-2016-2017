using System.Data.SqlClient;
using System.IO;

namespace ImageCollector
{
    public class ImageCollector
    {
        static void Main(string[] args)
        {
            string connecionString = "Server = .; Database = NORTHWND; Integrated Security=true";
            var connection = new SqlConnection(connecionString);
            connection.Open();

            using (connection)
            {
                var command = new SqlCommand("SELECT Picture FROM Categories", connection);

                var reader = command.ExecuteReader();

                var i = 0;
                while (reader.Read())
                {
                    i++;
                    var image = (byte[])reader["Picture"];

                    WriteBinaryFile($"..//..//pic{i}.JPG", image);

                }
            }
        }
        private static void WriteBinaryFile(string fileName, byte[] fileContents)
        {
            FileStream stream = File.OpenWrite(fileName);
            using (stream)
            {
                stream.Write(fileContents, 78, fileContents.Length - 78);
            }
        }
    }
}