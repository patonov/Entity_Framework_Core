using System;
using System.Linq;
using System.Data.SqlClient;
using System.Text;

namespace IncreaseAgeStoredProcedure
{
    public class StartUp
    {
        private const string ConnectionString = @"Server=.;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            int minionId = int.Parse(Console.ReadLine());

            string result = IncreaseMinionAgeById(sqlConnection, minionId);

            Console.WriteLine(result);
        }

        private static string IncreaseMinionAgeById(SqlConnection sqlConnection, int minionId)
        {
            StringBuilder sb = new StringBuilder();

            string procName = "usp_GetOlder";
            using SqlCommand increaseAgeCommand = new SqlCommand(procName, sqlConnection);

            increaseAgeCommand.CommandType = System.Data.CommandType.StoredProcedure;
            increaseAgeCommand.Parameters.AddWithValue("@minionId", minionId);

            increaseAgeCommand.ExecuteNonQuery();

            string getMinionsInfoQueryText = @"SELECT [Name], Age FROM Minions WHERE Id = @minionId";
            using SqlCommand getMinionsInfoCommand = new SqlCommand(getMinionsInfoQueryText, sqlConnection);
            getMinionsInfoCommand.Parameters.AddWithValue("@minionId", minionId);

            SqlDataReader reader = getMinionsInfoCommand.ExecuteReader();
            reader.Read();

            string minionName = reader["Name"]?.ToString();
            string minionAge = reader["Age"]?.ToString();
            sb.AppendLine($"{minionName} - {minionAge} years old.");

            return sb.ToString().TrimEnd();
        }
    }
}
