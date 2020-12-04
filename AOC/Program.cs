using System;
using System.IO;
using System.Linq;

namespace AOC
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = @"e:\git\aoc2020\input\Day4A.txt";
            var lines = File.ReadAllText(inputFile).Replace($"{Environment.NewLine}{Environment.NewLine}", "~");
            var passports = lines.Split('~');
            var ans = 0;

            foreach (var passport in passports)
            {
                // separate each passport into it's parts
                var parts = passport.Replace($"{Environment.NewLine}", "~").Replace(' ', '~').Split('~');
                if (parts.Length < 7) continue;
                if (!parts.Where(p => p.Substring(0, 4) == "byr:").Any()) continue;
                if (!parts.Where(p => p.Substring(0, 4) == "iyr:").Any()) continue;
                if (!parts.Where(p => p.Substring(0, 4) == "eyr:").Any()) continue;
                if (!parts.Where(p => p.Substring(0, 4) == "hgt:").Any()) continue;
                if (!parts.Where(p => p.Substring(0, 4) == "hcl:").Any()) continue;
                if (!parts.Where(p => p.Substring(0, 4) == "ecl:").Any()) continue;
                if (!parts.Where(p => p.Substring(0, 4) == "pid:").Any()) continue;
                ans++;
            }
            Console.WriteLine(ans);
        }
    }
}
