using System;
using System.Linq;
using System.Data.SqlClient;
using System.Text;

namespace RemoveVillian
{
    class StartUp
    {
        private const string ConnectionString = @"Server=.;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            int villianId = int.Parse(Console.ReadLine());

            string result = RemoveVillianById(sqlConnection, villianId);

            Console.WriteLine(result);

        }

        private static string RemoveVillianById(SqlConnection sqlConnection, int villianId)
        {
            StringBuilder sb = new StringBuilder();

            using SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

            string getVillianNameQueryText = @"SELECT [Name] FROM Villians WHERE Id = @villianId";

            using SqlCommand GetVillianNameCommand = new SqlCommand(getVillianNameQueryText, sqlConnection);
            GetVillianNameCommand.Parameters.AddWithValue("@villianId", villianId);

            GetVillianNameCommand.Transaction = sqlTransaction;

            string villianName = GetVillianNameCommand.ExecuteScalar()?.ToString();

            if (villianName == null)
            {
                sb.AppendLine("No such villian was found.");
            }
            else
            {
                try
                {
                    string releaseMinionQueryText = @"DELETE FROM MinionsVillians WHERE VillianId = @villianId";
                    using SqlCommand releaseMinionCommand = new SqlCommand(releaseMinionQueryText, sqlConnection);
                    releaseMinionCommand.Parameters.AddWithValue("@villianId", villianId);
                    releaseMinionCommand.Transaction = sqlTransaction;

                    int releasedMinionsCount = releaseMinionCommand.ExecuteNonQuery();

                    string deleteVillianQueryText = @"DELETE FROM Villians WHERE Id = @villianId";
                    using SqlCommand DeleteVillianCommand = new SqlCommand(deleteVillianQueryText, sqlConnection);
                    DeleteVillianCommand.Parameters.AddWithValue("villianId", villianId);
                    DeleteVillianCommand.Transaction = sqlTransaction;

                    DeleteVillianCommand.ExecuteNonQuery();

                    sqlTransaction.Commit();

                    sb.AppendLine($"{villianName} was deleted.").AppendLine($"{releasedMinionsCount} minions were released.");
                }
                catch (Exception ex)
                {
                    sb.AppendLine(ex.Message);
                    try
                    {
                        sqlTransaction.RollBack();
                    }
                    catch (Exception rollbackEx)
                    {
                        sb.AppendLine(rollbackEx.Message);
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
