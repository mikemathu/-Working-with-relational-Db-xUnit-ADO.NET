using System;
using Microsoft.Data.Sqlite;
namespace SqliteConsoleTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var connection = new SqliteConnection("Data Source=:memory:")) //Specifies in-memory database in the connection string
            {
                connection.Open();
                var command = new SqliteCommand("SELECT 3;", connection); 
                long result = (long)command.ExecuteScalar(); //u expect the result of the command to be a scalar (single value).
                Console.WriteLine($"Command output: {result}");
            } //End of the using block disposes of the connection object
        }
    }
}
