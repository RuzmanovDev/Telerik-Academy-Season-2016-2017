using System;
using System.Data.SQLite;

namespace Sqlite
{
    class Sqlite
    {
        static void Main(string[] args)
        {

            string connectionString = "Data Source=..//..//data.db;Version=3;";

            ReadFromDB(connectionString);
            WriteNewBook(connectionString);
            ReadFromDB(connectionString);
        }

        private static void WriteNewBook(string connectionString)
        {
            var connection = new SQLiteConnection(connectionString);
            connection.Open();

            using (connection)
            {
                var sqlString = "INSERT INTO Books VALUES ('333','pesho','pesho', '2015', '1232323');";
                var command = new SQLiteCommand(sqlString, connection);

                command.ExecuteNonQuery();
            }
        }

        private static void ReadFromDB(string connectionString)
        {
            var connection = new SQLiteConnection(connectionString);
            connection.Open();

            using (connection)
            {
                var command = new SQLiteCommand("select * from books", connection);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    long id = (long)reader["Id"];
                    string title = (string)reader["Title"];
                    string author = (string)reader["Author"];
                    string publishDate = (string)reader["PublishDate"];
                    string isbn = (string)reader["ISBN"];

                    Console.WriteLine($"Id: {id}, Title: {title}, Author: {author}, PublishDate: {publishDate}, ISBN: {isbn}");
                }
            }
        }
    }
}
