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
            var memories = new Dictionary<long, long>();
            for (int i = 0; i < inputs.Length; i++)
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
                    // calculate locations to add value to
                    var value = long.Parse(memToAdd[1]);
                    var locations = new string[int.Parse(Math.Pow(2, mask.Count(m => m == 'X')).ToString())];

                    // calculate value to add
                    (int location, long value) mem = (int.Parse(memToAdd[0]), long.Parse(memToAdd[1]));
                    // get masked value
                    var binary = Convert.ToString(mem.location, 2).PadLeft(36, '0');
                    var toAdd = "";
                    var div = locations.Length / 2;
                    var x = "0";
                    for (int j = 0; j < 36; j++)
                    {
                        if (mask[j] == 'X')
                        {
                            for (int k = 0; k < locations.Length; k++)
                            {
                                locations[k] += toAdd + x;
                                // flip if necessary
                                if ((k + 1) % div == 0)
                                {
                                    x = x == "0" ? "1" : "0";
                                }
                                if (j == 35)
                                {
                                    var loc = Convert.ToInt64(locations[k], 2);
                                    if (memories.ContainsKey(loc))
                                        memories[loc] = value;
                                    else
                                        memories.Add(loc, value);
                                }
                            }
                            toAdd = "";
                            div /= 2;
                        }
                        else
                        {
                            toAdd += binary[j] == '1' || mask[j] == '1' ? '1' : '0';
                            if (j == 35)
                            {
                                for (int k = 0; k < locations.Length; k++)
                                {
                                    locations[k] += toAdd;
                                    var loc = Convert.ToInt64(locations[k], 2);
                                    if (memories.ContainsKey(loc))
                                        memories[loc] = value;
                                    else
                                        memories.Add(loc, value);
                                }
                                toAdd = "";
                            }


                        }
                    }
                }
                if (i == inputs.Length - 1) ans += memories.Select(m => m.Value).Sum();
            }


            Console.WriteLine(ans);
            Console.ReadLine();
        }
    }
}
