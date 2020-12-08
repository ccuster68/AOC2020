using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC
{
    class Program
    {
        static string[] lines;
        static List<int> listOfBags = new List<int>();
        static int ttlBags;

        static void Main(string[] args)
        {
            var inputFile = @"e:\git\aoc2020\input\Day7A.txt";
            lines = File.ReadAllLines(inputFile);

            ProcessBag("1 shiny gold bag", 1);

            Console.WriteLine(ttlBags);
        }

        // Dictionary of level / bag
        private static void ProcessBag(string bagInfo, int multiple)
        {
            var numberOfBags = int.Parse(bagInfo.Split(' ').First());

            // Will turn 1 shiny gold bags contain 2 dark red bags. to shiny gold bags contain
            var bagName = bagInfo.Replace(".", "").Substring(numberOfBags.ToString().Length + 1);
            bagName += bagName.EndsWith("bags") ? "" : "s";
            var bagSearchName = bagName + " contain ";
            // Get list of bags in this bag
            var bagList = lines.Where(r => Regex.Match(r, $"^{bagSearchName}").Success)
                                .Select(r => r.Substring(bagSearchName.Length)).First().Split(',').Select(bl => bl.Trim()).ToList();

            foreach (var bag in bagList)
            {
                if (bag == "no other bags.") continue;
                numberOfBags = int.Parse(bag.TrimStart().Split(' ').First()) * multiple;
                ttlBags += numberOfBags;
                ProcessBag(bag, numberOfBags);
            }
        }
    }
}
