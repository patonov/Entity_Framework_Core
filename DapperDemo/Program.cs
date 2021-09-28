using System;
using System.Collections.Generic;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DapperDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var connection = new SqlConnection("Server=DESKTOP-79AOHR2;Database=SoftUni;Integrated Security=true"))
            {
                var projects = connection.Query<ProjectInfo>("SELECT Name, ProjectID FROM Projects WHERE ProjectID > 100");

                foreach (var project in projects)
                {
                    Console.WriteLine(project.Name);
                }
            }
        }
    }

    public class ProjectInfo
    { 
        public string Name { get; set; }

        public int Id { get; set; }
    
    }
        
}
