using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = @"e:\git\aoc2020\input\Day3A.txt";
            var lines = File.ReadAllLines(inputFile);//.Select(y => int.Parse(y)).ToArray();
            List<(int, int)> slopes = new List<(int, int)>();
            slopes.Add((1, 1));
            slopes.Add((3, 1));
            slopes.Add((5, 1));
            slopes.Add((7, 1));
            slopes.Add((1, 2));

            Int64 ans = 1;

            foreach (var slope in slopes)
            {
                var trees = 0;
                for (int i = slope.Item2; i < lines.Length; i +=slope.Item2)
                {
                    // make sure we have enough repeats
                    var line = string.Concat((Enumerable.Repeat(lines[i], (slope.Item1+1) * (i))));
                    if (line[slope.Item1 * i/slope.Item2] == '#') trees++;
                }
                ans *= trees;
            }
            Console.WriteLine(ans);
        }
    }
}
