using System;
using System.Linq;
using System.Data.SqlClient;
using System.Text;

namespace AdoApp1
{
    public class Program
    {
        private const string ConnectionString = @"Server=DESKTOP-79AOHR2;Database=MinionsDB;Integrated Security=true;";

        public static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            string minionTownQueryText = @"SELECT Id FROM Towns WHERE [Name] = 'Plovdiv'";
            using SqlCommand minionTownCommand = new SqlCommand(minionTownQueryText, sqlConnection);

            string minionTownId = minionTownCommand.ExecuteScalar().ToString();

            Console.WriteLine(minionTownId);
        }
    }
}
