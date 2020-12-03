using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = @"e:\git\aoc2020\input\Day3A.txt";
            var lines = File.ReadAllLines(inputFile);//.Select(y => int.Parse(y)).ToArray();
            List<(int h, int v)> slopes = new List<(int, int)>
            {
                (1, 1),
                (3, 1),
                (5, 1),
                (7, 1),
                (1, 2)
            };

            Int64 ans = 1;

            foreach (var (h, v) in slopes)
            {
                var trees = 0;
                for (int i = v; i < lines.Length; i += v)
                {
                    // make sure we have enough repeats
                    var line = string.Concat(Enumerable.Repeat(lines[i], (h + 1) * i));
                    if (line[h * i / v] == '#') trees++;
                }
                ans *= trees;
            }
            Console.WriteLine(ans);
        }
    }
}
