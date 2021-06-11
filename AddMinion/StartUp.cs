using System;
using System.Linq;
using System.Data.SqlClient;
using System.Text;

namespace AddMinion
{
    public class StartUp
    {
        private const string ConnectionString = @"Server=.;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            string[] minionsInput = Console.ReadLine().Split(':').ToArray();

            string[] minionsInfo = minionsInput[1].Split(' ').ToArray();

            string[] villiansInput = Console.ReadLine().Split(':').ToArray();

            string[] villiansInfo = villiansInput[1].Split(' ').ToArray();

            string result = AddMinionToDatabase(sqlConnection, minionsInfo, villiansInfo);

            Console.WriteLine(result);
        }

        private static string AddMinionToDatabase(SqlConnection sqlConnection, string[] minionsInfo, string[] villiansInfo)
        {
            StringBuilder output = new StringBuilder(); 

            string minionName = minionsInfo[0];
            string minionAge = minionsInfo[1];
            string minionTown = minionsInfo[2];

            string villianName = villiansInfo[0];

            string townId = EnsureTownExists(sqlConnection, minionTown, output);

            string villianId = EnsureVillianExists(sqlConnection, villianName, output);

            string insertMinionQueryText = @"INSERT INTO Minions ([Name], Age, TownId) VALUES (@minionName, @minionAge, @townId)";
            using SqlCommand insertMinionCommand = new SqlCommand(insertMinionQueryText, sqlConnection);
            insertMinionCommand.Parameters.AddRange(new []
            {
                new SqlParameter("@minionName", minionName),
                new SqlParameter("@minionAge", minionAge),
                new SqlParameter("@townId", townId)
            });

            insertMinionCommand.ExecuteNonQuery();

            string getMinionIdQueryText = @"SELECT Id FROM Minions WHERE [Name] = @minionName";
            using SqlCommand getMinionIdCommand = new SqlCommand(getMinionIdQueryText, sqlConnection);
            getMinionIdCommand.Parameters.AddWithValue("@minionName", minionName);
            string minionId = getMinionIdCommand.ExecuteScalar().ToString();

            string insertIntoMappingQueryText = @"INSERT INTO MinionsVillians(MinionId, VillianId) VALUES (@minionId, @villianId)";
            using SqlCommand insertIntoMappingCommand = new SqlCommand(insertIntoMappingQueryText, sqlConnection);
            insertIntoMappingCommand.Parameters.AddRange(new[] {
                new SqlParameter("@minionId", minionId),
                new SqlParameter("@villianId", villianId)
            });

            insertIntoMappingCommand.ExecuteNonQuery();

            output.AppendLine($"Successfully added {minionName} to be a minion of {villianName}.");

            return output.ToString().TrimEnd();
        }

        private static string EnsureVillianExists(SqlConnection sqlConnection, string villianName, StringBuilder output)
        {
            string getVillianIdQueryText = @"SELECT Id FROM Villians WHERE [Name] = @name";
            using SqlCommand getVillianIdCommand = new SqlCommand(getVillianIdQueryText, sqlConnection);
            getVillianIdCommand.Parameters.AddWithValue("@name", villianName);

            string villianId = getVillianIdCommand.ExecuteScalar()?.ToString();

            if (villianId == null)
            {
                string getFcatorIdQueryText = @"SEECT Id FROM EvilnessFactors WHERE [Name] = 'Evil'";
                using SqlCommand getFactorIdCommand = new SqlCommand(getFcatorIdQueryText, sqlConnection);

                string factorId = getFactorIdCommand.ExecuteScalar()?.ToString();

                string insertVillianQueryText = @"INSERT INTO Villians ([Name], EvilnessFactorId) VALUES (@villianName, @factorId)";
                using SqlCommand insertVillianCommand = new SqlCommand(insertVillianQueryText, sqlConnection);
                insertVillianCommand.Parameters.AddWithValue("@villianName", villianName);

                insertVillianCommand.Parameters.AddWithValue("@factorId", factorId);

                insertVillianCommand.ExecuteNonQuery();

                getVillianIdCommand.ExecuteScalar().ToString();

                output.AppendLine($"Villian {villianName} was added to the database.");
            }

            return villianId;
        }

        private static string EnsureTownExists(SqlConnection sqlConnection, string minionTown, StringBuilder output)
        {
            string getTownIdQueryText = @"SELECT Id FROM Towns WHERE [Name] = @townName";
            using SqlCommand getTownIdCommand = new SqlCommand(getTownIdQueryText, sqlConnection);
            getTownIdCommand.Parameters.AddWithValue("@townName", minionTown);

            string townId = getTownIdCommand.ExecuteScalar()?.ToString();

            if (townId == null)
            {
                string insertTownQueryText = @"INSERT INTO Towns([Name], CountryCode) VALUES (@townName, 1)";
                using SqlCommand insertTownCommand = new SqlCommand(insertTownQueryText, sqlConnection);
                insertTownCommand.Parameters.AddWithValue("@townName", minionTown);

                insertTownCommand.ExecuteNonQuery();

                townId = getTownIdCommand.ExecuteScalar().ToString();

                output.AppendLine($"Town {minionTown} was added to the database.");

            }
            return townId;
        }
    }
}
