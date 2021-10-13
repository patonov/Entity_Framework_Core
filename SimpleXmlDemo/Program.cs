using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

namespace SimpleXmlDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // var xml = File.ReadAllText("Planes.xml");

            XDocument xDocument = XDocument.Load("Planes.xml");

            // Console.WriteLine(xDocument);

            Console.WriteLine(xDocument.Root.Elements().Count());

            Console.WriteLine(xDocument.Root.Elements().FirstOrDefault(x => x.Element("color").Value == " Blue "));

            Console.WriteLine(xDocument.Root.Elements().FirstOrDefault(x => x.Element("color").Value == " Blue ").Element("year").Value);
        }
    }
}
