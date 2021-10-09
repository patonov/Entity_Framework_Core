using System;
using System.Text.Json;
using System.IO;

namespace JsonDemo
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; } = DateTime.Now;
        
        public int TemperatureC { get; set; } = 30;
        
        public string Summary { get; set; } = "Hot summer day";
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var weather = new WeatherForecast();

            string json = JsonSerializer.Serialize(weather);

            File.WriteAllText("weather.json", json);

            Console.WriteLine(json);

            var jsonString = File.ReadAllText("weather.json");
            var weatherResult = JsonSerializer.Deserialize<WeatherForecast>(jsonString);
            

        }
    }
}
