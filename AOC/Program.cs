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
        static List<(int numberOfBags, int multiple)> listOfBags = new List<(int, int)>();
        
        static void Main(string[] args)
        {
            var inputFile = @"e:\git\aoc2020\input\Day7ATEST.txt";
            lines = File.ReadAllLines(inputFile);
            // get bags that are in shiny gold bag

            ProcessBag("1 shiny gold bag", 1);

            Double count = 0;
            foreach (var bag in listOfBags)
            {
                count += bag.multiple;
            }

            Console.WriteLine(count);
        }

        // Dictionary of level / bag
        private static void ProcessBag(string bagInfo, int multiple)
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

            List<(string bag, int level)> bagsToProcess = new List<(string bag, int level)>();
            foreach (var bag in bagList)
            {
                try
                {
                    numberOfBags = int.Parse(bag.TrimStart().Split(' ').First());
                    listOfBags.Add((numberOfBags, numberOfBags*multiple));
                    bagsToProcess.Add((bag, numberOfBags));
                }
                catch
                {
                    // no other bags
                }
            }
            foreach (var bag in bagsToProcess)
            {
                ProcessBag(bag.bag, bag.level);
            }

        }
    }
}
