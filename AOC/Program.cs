using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC
{
    class Program
    {
        static int acc;
        static void Main(string[] args)
        {
            var inputFile = @"e:\git\aoc2020\input\Day10.txt";
            // get and put input into array of operation, arg
            var input = File.ReadAllLines(inputFile).Select(i => Int64.Parse(i)).ToList();
            input.Add(0);
            input.Sort();
            var oneJolt = 0;
            var threeJolt = 1;

            for (int i = input.Count-1; i >= 1; i--)
            {
                var diff = input[i] - input[i - 1];
                if (diff == 3) threeJolt++;
                if (diff == 1) oneJolt++;

                
            }
            Console.WriteLine(oneJolt*threeJolt);
        }
    }
}