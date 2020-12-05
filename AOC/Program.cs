using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = @"e:\git\aoc2020\input\Day5A.txt";
            var lines = File.ReadAllLines(inputFile);

            var ans = 0d;

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
                ans = Math.Max(ans, f * 8 + l);
            }
            Console.WriteLine(ans);
        }
    }
}
