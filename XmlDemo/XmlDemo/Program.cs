using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XmlDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(food[]),
                new XmlRootAttribute("breakfast_menu"));

            food[] menus = (food[])xmlSerializer.Deserialize(File.OpenRead("../../../FoodMenu.xml"));

            foreach (var m in menus)
            {
                Console.WriteLine(m.name);
            }

            Console.WriteLine("=========================================");

            xmlSerializer = new XmlSerializer(typeof(food[]), new XmlRootAttribute("breakfast_menu"));
            xmlSerializer.Serialize(File.OpenWrite("../../../myXmlFile.xml"), menus);

            Console.WriteLine("=========================================");

            XDocument xDocument = XDocument.Load("../../../FoodMenu.xml");
            
            Console.WriteLine(xDocument.Declaration.Encoding);
            Console.WriteLine("=========================================");

            Console.WriteLine(xDocument.Declaration.Version);
            Console.WriteLine("=========================================");

            Console.WriteLine(xDocument.Root.Elements().Count());
            Console.WriteLine("=========================================");

            Console.WriteLine(xDocument.Root.Elements().FirstOrDefault(x => x.Element("name").Value.Contains("Strawberry")));
            Console.WriteLine("=========================================");

            Console.WriteLine(xDocument.Root.Elements().FirstOrDefault(x => x.Element("name").Value == "Belgian Waffles"));
            Console.WriteLine("=========================================");

            Console.WriteLine(xDocument.Root.Elements().FirstOrDefault(x => x.Element("name").Value == "Belgian Waffles")
                .Element("description").Value);
            Console.WriteLine("=========================================");

            






        }
    }
}
