using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AOC
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = @"e:\git\aoc2020\input\Day13.txt";
            var inputs = File.ReadAllLines(inputFile);
            var earliestTime = int.Parse(inputs[0]);
            var busIds = inputs[1].Split(',').Where(b => int.TryParse(b, out var a)).Select(b => int.Parse(b)).ToList();

            List<(int earliestTime, int busId)> lFound = new List<(int, int)>();
            var bestTime = int.MaxValue;
            var bestBusId = 0;
            foreach (var busId in busIds)
            {
                var busTime = ((earliestTime / busId) + 1) * busId;
                var curBestTime = bestTime;
                bestTime = Math.Min(bestTime, busTime);
                if (curBestTime > bestTime) bestBusId = busId;
            }
            Console.WriteLine((bestTime - earliestTime) * bestBusId);
        }
    }
}
