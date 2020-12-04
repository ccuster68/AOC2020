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
                if (!parts.Where(p => Regex.Match(p, "^byr:(19[2-9]\\d|200[0-2])$").Success).Any()) continue;
                if (!parts.Where(p => Regex.Match(p, "^iyr:(201\\d|2020)$").Success).Any()) continue;
                if (!parts.Where(p => Regex.Match(p, "^eyr:(202\\d|2030)$").Success).Any()) continue;
                if (!parts.Where(p => Regex.Match(p, "^hgt:(1[5-8]\\dcm|19[0-3]cm|59in|6\\din|7[0-6]in)$").Success).Any()) continue;
                if (!parts.Where(p => Regex.Match(p, "^hcl:(#[a-f0-9]{6})$").Success).Any()) continue;
                if (!parts.Where(p => Regex.Match(p, "^ecl:(amb|blu|brn|gry|grn|hzl|oth)$").Success).Any()) continue;
                if (!parts.Where(p => Regex.Match(p, "^pid:\\d{9}$").Success).Any()) continue;

                ans++;
            }
            Console.WriteLine(ans);
        }
    }
}
