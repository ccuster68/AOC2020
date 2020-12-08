using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC
{
    class Program
    {

        static void Main(string[] args)
        {
            var inputFile = @"e:\git\aoc2020\input\Day8A.txt";
            var lines = File.ReadAllLines(inputFile);
            var operations = new List<(string op, int arg)>();
            var operationsHit = new List<int>();
            var acc = 0;
            var pos = 0;
            foreach (var line in lines)
            {
                operations.Add((line.Split(' ')[0], int.Parse(line.Split(' ')[1])));
            }



            do
            {
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

            Console.WriteLine(acc);
        }
    }
}
