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
            var inputFile = @"e:\git\aoc2020\input\Day4A.txt";
            var lines = File.ReadAllText(inputFile).Replace($"{Environment.NewLine}{Environment.NewLine}", "~");
            var passports = lines.Split('~');
            var ans = 0;

            foreach (var passport in passports)
            {
                // separate each passport into it's parts
                var parts = passport.Replace($"{Environment.NewLine}", "~").Replace(' ', '~').Split('~');
                if (parts.Length < 7) continue;
                if (!parts.Where(p => Regex.Match(p, "^byr:").Success).Any()) continue;
                if (!parts.Where(p => Regex.Match(p, "^iyr:").Success).Any()) continue;
                if (!parts.Where(p => Regex.Match(p, "^eyr:").Success).Any()) continue;
                if (!parts.Where(p => Regex.Match(p, "^hgt:").Success).Any()) continue;
                if (!parts.Where(p => Regex.Match(p, "^hcl:").Success).Any()) continue;
                if (!parts.Where(p => Regex.Match(p, "^ecl:").Success).Any()) continue;
                if (!parts.Where(p => Regex.Match(p, "^pid:").Success).Any()) continue;
                ans++;
            }
            Console.WriteLine(ans);
        }
    }
}
