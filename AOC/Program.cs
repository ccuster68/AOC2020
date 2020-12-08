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
        static Dictionary<string, Dictionary<int, int>> listOfBags = new Dictionary<string, Dictionary<int, int>>();
        static void Main(string[] args)
        {
            var inputFile = @"e:\git\aoc2020\input\Day7ATEST.txt";
            lines = File.ReadAllLines(inputFile);
            // get bags that are in shiny gold bag

            ProcessBag("1 shiny gold bag", 0);

            Double count = 0;
            foreach (var bag in listOfBags)
            {
                foreach (var subBags in bag.Value)
                {
                    count += Math.Pow(subBags.Value, subBags.Key);
                }
            }
            
            Console.WriteLine(count);
        }

        // Dictionary of level / bag
        private static void ProcessBag(string bagInfo, int level)
        {
            var numberOfBags = 0;
            try
            {
                numberOfBags = int.Parse(bagInfo.Split(' ').First());
            }
            catch
            {
                return;
            }
            // Will turn 1 shiny gold bags contain 2 dark red bags. to shiny gold bags contain
            var bagName = bagInfo.Replace(".", "").Substring(numberOfBags.ToString().Length + 1);
            bagName += bagName.EndsWith("bags") ? "" : "s";
            var bagSearchName = bagName + " contain ";
            // Get list of bags in this bag
            var bagList = lines.Where(r => Regex.Match(r, $"^{bagSearchName}").Success)
                                .Select(r => r.Substring(bagSearchName.Length)).First().Split(',').Select(bl => bl.Trim()).ToList();

            foreach (var bag in bagList)
            {
                if (level>0)
                {
                    var dicToAdd = new Dictionary<int, int>
                    {
                        { level, numberOfBags }
                    };
                    listOfBags.Add(bagName, dicToAdd);
                }
                level++;
                ProcessBag(bag, level);
            }

        }
    }
}
