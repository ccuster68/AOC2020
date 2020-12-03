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

            var trees = 0;
            for (int i = 1; i < lines.Length; i++)
            {
                // make sure we have enough repeats
                var line = string.Concat((Enumerable.Repeat(lines[i],3 * (i))));

                if (line[3 * i] == '#') trees++;
                
            }
            Console.WriteLine(trees);
        }
    }
}
