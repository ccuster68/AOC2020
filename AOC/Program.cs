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
            var lines = File.ReadAllText(inputFile).Replace($"{Environment.NewLine}{Environment.NewLine}", "~");
            var groups = lines.Split('~');

            var ans = 0;
            foreach (var group in groups)
            {
                var people = group.Replace($"{Environment.NewLine}","~").Split('~');
                var groupCount = 0;
                foreach(var c in people[0])
                {
                    if (people.Count(p => p.Contains(c)) == people.Length) groupCount++;
                }
                ans += groupCount;
            }
            
            Console.WriteLine(ans);
        }
    }
}
