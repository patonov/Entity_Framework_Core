using System;
using System.Data.SqlClient;
using System.Text;

namespace MinionNames
{
    public class StartUp
    {
        private const string ConnectionString = @"Server=.;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {

            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);

            sqlConnection.Open();

            int villianId = int.Parse(Console.ReadLine());

            string result = GetMinionsInfoAboutVillian(sqlConnection, villianId);

            Console.WriteLine(result);
                       
        }

        private static string GetMinionsInfoAboutVillian(SqlConnection sqlConnection, int villianId)
        {
            StringBuilder sb = new StringBuilder();

            string getVillianNameQueryText = @"SELECT [Name] FROM Villians WHERE Id = @villianId";
            using SqlCommand getVillianNameCommand = new SqlCommand(getVillianNameQueryText, sqlConnection);
            getVillianNameCommand.Parameters.AddWithValue("@villianId", villianId);

            string villianName = getVillianNameCommand.ExecuteScalar()?.ToString();

            if (villianName == null)
            {
                sb.AppendLine($"No Villian with {villianId} id exists in the database.");
            }
            else
            {
                sb.AppendLine($"Villian: {villianName}");

                string getMinionsInfoQueryText = @"SELECT m.[Name], m.Age 
                                                    FROM Villians AS v
                                                    LEFT OUTER JOIN MinionsVillians AS mv
                                                    ON v.Id = mv.VillianId
                                                    LEFT OUTER JOIN Minions AS m
                                                    ON mv.MinionId = m.Id
                                                    WHERE v.[Name] = @villianName
                                                    ORDER BY m.[Name]";
                SqlCommand getMinionsInfoCommand = new SqlCommand(getMinionsInfoQueryText, sqlConnection);
                getMinionsInfoCommand.Parameters.AddWithValue("@villianName", villianName);

                using SqlDataReader reader = getMinionsInfoCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    int rowNum = 1;

                    while (reader.Read())
                    {
                        string minionsName = reader["Name"]?.ToString();
                        string minionsAge = reader["Age"]?.ToString();

                        sb.AppendLine($"{rowNum}. {minionsName} {minionsAge}");
                        rowNum++;
                    }
                }
                else
                {
                    sb.AppendLine("(no minions)");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
