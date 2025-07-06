// Sql server connection example with windows authentication
// This code connects to a SQL Server database and retrieves data from a table named 'users'

using Microsoft.Data.SqlClient;
var connectionString = "Server=Temur;Database=Test1;Integrated Security=True;TrustServerCertificate=True";
using (var connection = new SqlConnection(connectionString))
{
    try
    {
        connection.Open();
        SqlCommand command = new SqlCommand("SELECT * from users", connection);
        using(var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                Console.WriteLine($"User: {reader["name"]}, age: {reader["age"]}");
            }
        }
        Console.WriteLine("Connection to SQL Server established successfully.");
    }
    catch (SqlException ex)
    {
        Console.WriteLine($"SQL Error: {ex.Message}");
    }
}
