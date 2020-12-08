using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC
{
    class Program
    {
        static int acc;
        static void Main(string[] args)
        {
            var inputFile = @"e:\git\aoc2020\input\Day8A.txt";
            // get and put input into array of operation, arg
            (string op, int arg)[] operations = File.ReadAllLines(inputFile).Select(l => (l.Split(' ')[0], int.Parse(l.Split(' ')[1]))).ToArray();
            // holds if an operation has already been hit, infinite loop
            var operationsHit = new List<int>();

            process(operations, operationsHit);
            Console.WriteLine(acc);
        }

        static bool process((string op, int arg)[] operations, List<int> operationsHit)
        {
            acc = 0; // set accumulator total
            var pos = 0; // starting postition
            do
            {
                operationsHit.Add(pos);
                // handle operation
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
            } while (!operationsHit.Contains(pos));

            return true;
        }
    }
}
