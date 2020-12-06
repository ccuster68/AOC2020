using System;
using System.IO;
using System.Linq;

namespace AOC
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = @"e:\git\aoc2020\input\Day6A.txt";
            var lines = File.ReadAllText(inputFile).Replace($"{Environment.NewLine}{Environment.NewLine}", "~").Replace($"{Environment.NewLine}","");
            var groups = lines.Split('~');
            var ans = 0;
            foreach (var group in groups)
            {
                ans += group.Distinct().Count();
            }
            
            Console.WriteLine(ans);
        }
    }
}
