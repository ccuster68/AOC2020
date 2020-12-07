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
        static void Main(string[] args)
        {
            var inputFile = @"e:\git\aoc2020\input\Day7ATEST.txt";
            lines = File.ReadAllLines(inputFile);
            // get bags that are in shiny gold bag

            Int64 count = GetBagCount("1 shiny gold bag");

            Console.WriteLine(count);

        }

        private static Int64 GetBagCount(string bagInfo)
        {
            int multiplier;
            // when first string is not a number, then there are no more container bags
            try
            {
                multiplier = int.Parse(bagInfo.Split(' ').First());
            }
            catch
            {
                return 1;
            }
            Int64 retValue = multiplier;
            var bagName = bagInfo.Replace(".","").Substring(multiplier.ToString().Length + 1) + (multiplier > 1 ? " contain " : "s contain ");

            // Get list of bags in this bag
            var bagList = lines.Where(r => Regex.Match(r, $"^{bagName}").Success)
                                .Select(r => r.Substring(bagName.Length)).First().Split(',').Select(bl => bl.Trim()).ToList();


            // assuming bags always have container
            foreach (var bag in bagList)
            {
                retValue += GetBagCount(bag);
            }
            return retValue;
        }
    }
}
