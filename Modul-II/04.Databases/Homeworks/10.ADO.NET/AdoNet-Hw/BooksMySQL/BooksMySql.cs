using System;
using MySql.Data.MySqlClient;

namespace BooksMySQL
{
    public class BooksMySql
    {
        static void Main(string[] args)
        {
            Console.Write("Enter pass: ");
            string pass = Console.ReadLine();

            string connectionString = "Server=localhost;Database=bookstore;Uid=root;Pwd=" + pass + ";";

            ReadFromDB(connectionString);
            WriteNewBook(connectionString);
            ReadFromDB(connectionString);
        }

        private static void WriteNewBook(string connectionString)
        {
            var connection = new MySqlConnection(connectionString);
            connection.Open();

            using (connection)
            {
                var sqlString = "INSERT INTO `bookstore`.`books` ( `title`, `author`, `publish-date`, `isbn`) VALUES ( 'WORK', 'pesho', '2012-10-10', '1232323');";
                var command = new MySqlCommand(sqlString, connection);

                var reader = command.ExecuteNonQuery();
            }
        }

        private static void ReadFromDB(string connectionString)
        {
            var connection = new MySqlConnection(connectionString);
            connection.Open();

            using (connection)
            {
                var command = new MySqlCommand("select * from books", connection);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = (int)reader["id"];
                    string title = (string)reader["title"];
                    string author = (string)reader["author"];
                    DateTime publishDate = (DateTime)reader["publish-date"];
                    string isbn = (string)reader["isbn"];

                    Console.WriteLine($"Id: {id}, Title: {title}, Author: {author}, PublishDate: {publishDate}, ISBN: {isbn}");
                }
            }
        }
    }
}
