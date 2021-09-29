using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.SqlServer;
using Z.EntityFramework.Plus;


namespace LinqDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            var dbContext = new MinionsDBContext();
            dbContext.Towns.Where(x => x.Id <= 3).DeleteAsync();



        }
    }
}
