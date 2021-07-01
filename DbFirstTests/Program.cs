using System;
using System.Linq;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;
using System.Text;

namespace DbFirstTests.Models
{
    public class Program
    {
        static void Main(string[] args)
        {
            MinionsDBContext minionsDB = new MinionsDBContext();

            var superPowerVillains = minionsDB.Villains.Where(x => x.EvilnessFactor.Name == "Super evil").ToList();

            foreach (var spv in superPowerVillains)
            {
                Console.WriteLine(spv.Name);
            }
        }
    }
}
