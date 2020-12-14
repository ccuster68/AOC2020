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
            var inputFile = @"e:\git\aoc2020\input\Day14.txt";
            var inputs = File.ReadAllLines(inputFile);

            long ans = 0;
            var mask = new char[36];
            var memories = new Dictionary<int, long>();
            for (long i = 0; i < inputs.Length; i++)
            {
                var ansArray = new char[36];
                var memToAdd = inputs[i].Replace("mem[", "").Replace("] =", "").Split(' ');

                //List<(long location, long value)> memories = new List<(long, long)>();
                if (inputs[i].StartsWith("mask"))
                { 
                    mask = inputs[i].Split(' ')[2].ToCharArray();  
                }
                else
                {
                    // calculate value to add
                    (int location, long value) mem = (int.Parse(memToAdd[0]), long.Parse(memToAdd[1]));
                    // get masked value
                    var binary = Convert.ToString(mem.value, 2).PadLeft(36, '0');
                    for (int j = 0; j < 36; j++)
                    {
                        ansArray[j] = ((binary[j] == '1' && mask[j] != '0') || mask[j] == '1') ? '1' : '0';
                    }
                    memories[mem.location]= Convert.ToInt64(new String(ansArray), 2);
                }

                if (i==inputs.Length-1) ans += memories.Select(m => m.Value).Sum();
            }


            Console.WriteLine(ans);
            Console.ReadLine();
        }
    }
}
