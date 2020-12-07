using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = @"e:\git\aoc2020\input\Day7A.txt";
            var lines = File.ReadAllLines(inputFile);
            // Get direct rules that contain shiny gold bags
            
            var bagList = lines.Where(r => Regex.Match(r, "contain .*shiny gold bag").Success).Select(r => r.Substring(0, r.IndexOf("s contain "))).ToList();
            do
            {
                var lastCount = bagList.Count;
                // Add bags that are not in the bagList and can contain a bag that contains the shiny gold bag
                bagList.AddRange(
                    lines.Where(r => !bagList.Contains(r.Substring(0, r.IndexOf("s contain "))) && bagList.Any(bl => Regex.Match(r, $"contain.* {bl}").Success))
                    .Select(r => r.Substring(0, r.IndexOf("s contain "))).ToList());
                if (bagList.Count==lastCount) break;
            } while (true) ;

                        
            Console.WriteLine(bagList.Count);
        }
    }
}
