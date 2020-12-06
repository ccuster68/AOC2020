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
            var inputFile = @"e:\git\aoc2020\input\Day6ATEST.txt";
            var lines = File.ReadAllLines(inputFile);

            var ans = 0d;
            var list = new List<double>();
            foreach (var line in lines)
            {
                var b = 127d;
                var f = 0d;
                var r = 7d;
                var l = 0d;
                for (int i = 6; i >= 0; i--)
                {
                    if (line[6 - i] == 'F')
                        b -= Math.Pow(2, i);
                    else
                        f += Math.Pow(2, i);

                    // 2-1-0
                    if (i < 3)
                    {
                        if (line[9 - i] == 'L')
                            r -= Math.Pow(2, i);
                        else
                            l += Math.Pow(2, i);
                    }
                }
                list.Add(f * 8 + l);
            }

            list.Sort();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] + 1 != list[i + 1])
                {
                    ans = list[i] + 1;
                    break;
                }
            }
            Console.WriteLine(ans);
        }
    }
}
