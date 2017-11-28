using HtmlAgilityPack;
using System;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var lernData = "C:/Users/bartoszjaniak/Projekty/HTMLBrowser/ConsoleApp/bin/Debug/netcoreapp2.0/inputData.html";            
            var lernWeb = new HtmlWeb();
            var lernDoc = lernWeb.Load(lernData);

            var testData = "C:/Users/bartoszjaniak/Projekty/HTMLBrowser/ConsoleApp/bin/Debug/netcoreapp2.0/testData.html";
            var testWeb = new HtmlWeb();
            var testDoc = lernWeb.Load(testData);

            // wyciąganie xpath szukanego elementu
            var nodeLocation = lernDoc.DocumentNode
                .Descendants()
                .Where(d =>
                   d.Attributes.Contains("class")
                   &&
                   d.Attributes["class"].Value.Contains("selectedText")
                );



            Console.WriteLine("Znaleziona ścieżka" + nodeLocation.First().XPath);


            var nodeResult = testDoc.DocumentNode.SelectNodes(nodeLocation.First().XPath);

            Console.WriteLine("Pasujące wyniki:");

            foreach (var nNode in nodeResult)
            {
                if (nNode.NodeType == HtmlNodeType.Element)
                {
                    Console.WriteLine(nNode.InnerText);     
                }
            }

            Console.ReadKey();
        
        }
    }
}
