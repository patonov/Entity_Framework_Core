using System;
using System.Data.SqlClient;

namespace AdoNetDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection sqlConnection = new SqlConnection(
                "Server=127.0.0.1\\root;Database=soft_uni;Integrated Security=true"))
            {
                
                sqlConnection.Open();
                string command = "SELECT COUNT (*) FROM Employees";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                object result = sqlCommand.ExecuteScalar();

                Console.WriteLine(result);
            }
        }
    }
}
