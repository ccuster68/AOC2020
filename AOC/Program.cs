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
            var inputFile = @"e:\git\aoc2020\input\Day9A.txt";
            // get and put input into array of operation, arg
            var input = File.ReadAllLines(inputFile).Select(i => Int64.Parse(i)).ToArray();
            const int preamble = 25;
            var match = false;
            for (int i = preamble; i < input.Length; i++)
            {
                for (int j = i - 1; j > i - preamble; j--)
                {
                    for (int k = j - 1; k >= i - preamble; k--)
                    {
                        // is there a match
                        if (input[j] + input[k] == input[i])
                        {
                            match = true;
                            break;
                        }
                    }
                    if (match)
                        break;
                }
                if (!match)
                {
                    Console.WriteLine(input[i]);
                    break;
                }
                else
                {
                    match = false;
                }
            }

        }
    }
}