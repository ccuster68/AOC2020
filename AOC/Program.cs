using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AOC
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputs = File.ReadAllLines(@"e:\git\aoc2020\input\Day16.txt").ToList();

            var list = new List<int>();
            foreach (var input in inputs.Where(i => i.Contains(" or ")).ToList())
            {
                var firstIdx = input.IndexOf(": ") + 2;
                var secondIdx = input.IndexOf("-");
                var first = int.Parse(input.Substring(firstIdx, secondIdx-firstIdx));
                firstIdx = input.IndexOf("-") + 1;
                secondIdx = input.IndexOf(" or ");
                var second = int.Parse(input.Substring(firstIdx, secondIdx - firstIdx));
                firstIdx = input.IndexOf(" or ") + 4;
                secondIdx = input.IndexOf("-", firstIdx);
                var third = int.Parse(input.Substring(firstIdx, secondIdx - firstIdx));
                firstIdx = input.IndexOf("-", secondIdx)+1;
                var fourth = int.Parse(input.Substring(firstIdx));

                for (int i = first; i < second+1; i++)
                {
                    if (!list.Contains(i)) list.Add(i);
                }

                for (int i = third; i < fourth + 1; i++)
                {
                    if (!list.Contains(i)) list.Add(i);
                }
            }
            list.Sort();

            var ans = 0l;

            bool found = false;
            foreach (var input in inputs.Where(i => !i.Contains(" or ")).ToList())
            {
                if (!found)
                {
                    if (input != "nearby tickets:")
                    {
                        continue;
                    }
                    else
                    {
                        found = true;
                        continue;
                    }
                }

                foreach (var num in input.Split(',').Select(n => int.Parse(n)).ToArray())
                {
                    if (!list.Contains(num))
                        ans += num;
                }

            }
                



            Console.WriteLine(ans);
            Console.ReadLine();
        }
    }
}
