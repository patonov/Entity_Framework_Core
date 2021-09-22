using System;
using System.Linq;
using EFdemo.Models;

namespace EFdemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new SoftUniContext();

            Console.WriteLine("Total number of projects {0}.", db.Projects.Count());

            foreach (Project p in db.Projects)
            {
                Console.WriteLine(p.Name);
            }

            Console.WriteLine("Number of projects whose title starts with ML {0}.", db.Projects.Count(x => x.Name.StartsWith("ML")));

            Console.WriteLine("They are as follow:");

            foreach (Project p in db.Projects.Where(x => x.Name.StartsWith("ML")))
            {
                Console.WriteLine(p.Name);
            }
        }
    }
}
