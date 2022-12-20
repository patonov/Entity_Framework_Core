using System;
using System.Text;
using System.Data.SqlClient;

namespace AdoNetDemoExercise
{
    class Program
    {
        private const string ConnectionString = @"Server=DESKTOP-79AOHR2;Database=MinionsDB;Integrated Security=true";

        static void Main(string[] args)
        {

            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            string command = "SELECT Id, Name, Age FROM Minions";

            SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);

            SqlDataReader dataReader = sqlCommand.ExecuteReader();

            using (dataReader)
            {
                while (dataReader.Read())
                {
                    int id = (int)dataReader["Id"];
                    string name = (string)dataReader["Name"];
                    int age = (int)dataReader["Age"];

                    Console.WriteLine($"Id => {id}, Name => {name}, Age => {age}");
                }

            }

            Console.WriteLine("================================================");

            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            string commandString = "SELECT COUNT (*) FROM Minions";

            SqlCommand newCommand = new SqlCommand(commandString, connection);

            int number = (int)newCommand.ExecuteScalar();

            Console.WriteLine(number);

            Console.WriteLine("================================================");


            using SqlConnection updateConnection = new SqlConnection(ConnectionString);
            updateConnection.Open();

            string updateCommandString = "UPDATE Minions SET Age = Age * 1.5";

            SqlCommand updateCommand = new SqlCommand(updateCommandString, updateConnection);

            int result = updateCommand.ExecuteNonQuery();

            Console.WriteLine(result + " rows affected by update command.");

            Console.WriteLine("================================================");
        }
    }
}
