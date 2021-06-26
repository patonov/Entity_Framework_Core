using System;
using System.Linq;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient.Server;
using System.Text;

namespace AddMinion
{
    class StartUp
    {
        private const string ConnectionString = @"Server=DESKTOP-79AOHR2;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            string[] minionsInput = Console.ReadLine().Split(':').ToArray();

            string[] minionsInfo = minionsInput[1].Split(' ').ToArray();

            string[] villainsInput = Console.ReadLine().Split(':').ToArray();

            string[] villainsInfo = villainsInput[1].Split(' ').ToArray();

            string result = AddMinionToDatabase(sqlConnection, minionsInfo, villainsInfo);

            Console.WriteLine(result);
        }

        private static string AddMinionToDatabase(SqlConnection sqlConnection, string[] minionsInfo, string[] villainsInfo)
        {
         
            StringBuilder output = new StringBuilder();

            string minionName = minionsInfo[0];
            string minionAge = minionsInfo[1];
            string minionTown = minionsInfo[2];

            string villainName = villainsInfo[0];

            string townId = EnsureTownExists(sqlConnection, minionTown, output);

            string villainId = EnsureVillianExists(sqlConnection, villainName, output);

            string insertMinionQueryText = @"INSERT INTO Minions ([Name], Age, TownId) VALUES (@minionName, @minionAge, @townId)";
            using SqlCommand insertMinionCommand = new SqlCommand(insertMinionQueryText, sqlConnection);
            insertMinionCommand.Parameters.AddRange(new[]
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

            string insertIntoMappingQueryText = @"INSERT INTO MinionsVillains(MinionId, VillainId) VALUES (@minionId, @villainId)";
            using SqlCommand insertIntoMappingCommand = new SqlCommand(insertIntoMappingQueryText, sqlConnection);
            insertIntoMappingCommand.Parameters.AddRange(new[] {
                new SqlParameter("@minionId", minionId),
                new SqlParameter("@villainId", villainId)
            });

            insertIntoMappingCommand.ExecuteNonQuery();

            output.AppendLine($"Successfully added {minionName} to be a minion of {villainName}.");

            return output.ToString().TrimEnd();
        }

        private static string EnsureVillianExists(SqlConnection sqlConnection, string villainName, StringBuilder output)
        {
            string getVillainIdQueryText = @"SELECT Id FROM Villians WHERE Name = @name";
            using SqlCommand getVillainIdCommand = new SqlCommand(getVillainIdQueryText, sqlConnection);
            getVillainIdCommand.Parameters.AddWithValue("@name", villainName);

            string villainId = getVillainIdCommand.ExecuteScalar()?.ToString();

            if (villainId == null)
            {
                string getFcatorIdQueryText = @"SEECT Id FROM EvilnessFactors WHERE Name = 'Evil'";
                using SqlCommand getFactorIdCommand = new SqlCommand(getFcatorIdQueryText, sqlConnection);

                string factorId = getFactorIdCommand.ExecuteScalar()?.ToString();

                string insertVillainQueryText = @"INSERT INTO Villains ([Name], EvilnessFactorId) VALUES (@villainName, @factorId)";
                using SqlCommand insertVillainCommand = new SqlCommand(insertVillainQueryText, sqlConnection);
                insertVillainCommand.Parameters.AddWithValue("@villainName", villainName);

                insertVillainCommand.Parameters.AddWithValue("@factorId", factorId);

                insertVillainCommand.ExecuteNonQuery();

                getVillainIdCommand.ExecuteScalar().ToString();

                output.AppendLine($"Villain {villainName} was added to the database.");
            }

            return villainId;
        }

        private static string EnsureTownExists(SqlConnection sqlConnection, string minionTown, StringBuilder output)
        {
            string getTownIdQueryText = @"SELECT Id FROM Towns WHERE Name = @townName";
            using SqlCommand getTownIdCommand = new SqlCommand(getTownIdQueryText, sqlConnection);
            getTownIdCommand.Parameters.AddWithValue("@townName", minionTown);

            string townId = getTownIdCommand.ExecuteScalar().ToString();

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
