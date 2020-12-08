using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC
{
    class Program
    {
        static int acc = 0;
        static void Main(string[] args)
        {
            var inputFile = @"e:\git\aoc2020\input\Day8ATEST.txt";
            var input = File.ReadAllText(inputFile);
            var index = 0;
            var acc = 0;
            do
            {
                var changedInput = "";
                index = input.IndexOf("jmp", index);
                if (index > 0)
                {
                    changedInput = input.Substring(0, index) + "nop" + input.Substring(index + 3);
                    if (process(changedInput))
                    {
                        Console.WriteLine(acc);
                        break;
                    }

                }
                else
                {
                    index = 0;
                    changedInput = input.Substring(0, index) + "nop" + input.Substring(index + 3);
                }


                if (process(changedInput))
                {
                    Console.WriteLine(acc);
                    break;
                }

            } while (true);
        }

        static bool process(string input)
        {
            acc = 0;
            var lines = input.Split('\n');

            var operations = new List<(string op, int arg)>();
            var operationsHit = new List<int>();

            var pos = 0;
            foreach (var line in lines)
            {
                operations.Add((line.Split(' ')[0], int.Parse(line.Split(' ')[1])));
            }

            do
            {
                if (pos == operations.Count) return true;
                if (operationsHit.Contains(pos)) break;

                operationsHit.Add(pos);

                switch (operations[pos].op)
                {
                    case "acc":
                        acc += operations[pos].arg;
                        pos++;
                        break;
                    case "jmp":
                        pos += operations[pos].arg;
                        break;
                    case "nop":
                        pos++;
                        break;
                    default:
                        break;
                }
            } while (true);

            return false;    
        }

    }
}
