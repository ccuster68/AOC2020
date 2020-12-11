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
            var inputFile = @"e:\git\aoc2020\input\Day10.txt";
            // get and put input into array of operation, arg
            var input = File.ReadAllLines(inputFile).Select(i => Int64.Parse(i)).ToList();
            input.Sort();
            long ans = 1;
            // only care about 3s and 1s since they are definite, but 2s can be derived
            var listJumps = new List<long>();

            for (int i = 0; i < input.Count - 1; i++)
            {
                var diff = input[i + 1] - input[i];
                listJumps.Add(diff);
            }

            // look for coniguous 1s
            for (int i = 0; i < listJumps.Count; i++)
            {

                if (listJumps[i] == 3) continue;
                // 7 combos of  1111: 
                if (i + 3 < listJumps.Count && listJumps[i + 1] == 1 && listJumps[i + 2] == 1 && listJumps[i + 3] == 1)
                {
                    ans *= 7;
                    i += 3;
                    continue;
                }

                // we add six since there are 4 combos of  111: 2! or 3,21,12,
                if (i + 2 < listJumps.Count && listJumps[i + 1] == 1 && listJumps[i + 2] == 1)
                {
                    // if it is the start then there are four 1s, so up the multiplier
                    if (i == 0) ans *= 7;
                    else ans *= 4;
                    i += 2;
                    continue;
                }
                // we have a 1 check for next being 1
                if (i + 1 < listJumps.Count && listJumps[i + 1] == 1)
                {
                    ans *= 2;
                    i++;
                    continue;
                }
            }

            Console.WriteLine(ans);
        }
    }
}