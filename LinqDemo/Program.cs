using System;
using System.Collections.Generic;
using System.Linq;
using LinqDemo.Models;
using Microsoft.EntityFrameworkCore.SqlServer;


namespace LinqDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new SoftUniContext();

            var selectedProjects = db.Projects.Where(x => x.Name.Contains("Mountain"))
                .OrderByDescending(x => x.Name)
                .ThenBy(x => x.ProjectId)
                .Select(x => new { Name = x.Name})
                .ToList();

            foreach (var pro in selectedProjects)
            {
                Console.WriteLine(pro.Name);
            }

            var employeeSelected = db.Employees.Where(x => x.Department.Name == "Sales").ToList();

            foreach (var emp in employeeSelected)
            {
                Console.Write(emp.FirstName + " ");
                Console.Write(emp.LastName);
                Console.WriteLine();
            }

        }
    }
}
