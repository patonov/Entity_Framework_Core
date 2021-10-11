using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Globalization;
using System.IO;
using CsvHelper;
using System.Text;

namespace CSVdemo
{
    public class Car
    {
        public int Year { get; set; }
       
        public string Make { get; set; }

        public string Model { get; set; }
        
        public string Description { get; set; }
        
        public decimal Price { get; set; }

    }


    class Program
    {
        static void Main(string[] args)
        {
            using (CsvReader reader = new CsvReader(new StreamReader("Cars.csv"), CultureInfo.InvariantCulture))
            {                
                var cars = reader.GetRecords<Car>().ToList(); 
            }

            var newCars = new List<Car>
            {
            new Car { Year = 1988, Make = "Jiguli",Model = "VAZ 1300", Description = "E nema takuv bokluk", Price = 140M },
            new Car { Year = 1972, Make = "Moskvitsch", Model = "1700", Description = "Pulen bokluk", Price = 100M},
            };

            using (CsvWriter writer = new CsvWriter(new StreamWriter("NewCars.csv"), CultureInfo.InvariantCulture))
            {
                writer.WriteRecords(newCars);
            }
            
            
            



        }
    }
}
