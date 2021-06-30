using System;
using System.Linq;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;
using System.Text;

namespace ORMtests
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new MinionsDBContext();

            dbContext.Database.EnsureCreated();

            dbContext.minions.Add(new Minions { Name = "Pesho", Age = 14, town = null, villain = null});

            string ConnectionString = @"Server=DESKTOP-79AOHR2;Database=MinionsDB;Integrated Security=true;";
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            string minionIdQueryText = @"SELECT Id FROM minions WHERE Name = 'Pesho'";
            using SqlCommand minionIdCommand = new SqlCommand(minionIdQueryText, sqlConnection);

            string minionId = minionIdCommand.ExecuteScalar().ToString();

            Console.WriteLine(minionId);

        }
    }
}
