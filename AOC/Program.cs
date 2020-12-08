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
            
            var opsToSwitch = new []{ "jmp", "nop" };

            for (int i = 0; i < operations.Length; i++)
            {
                // holds operations that have been address, infinite loop
                var operationsHit = new List<int>();
                
                if (opsToSwitch.Contains(operations[i].op))
                {
                    operations[i].op = operations[i].op == "jmp" ? "nop" : "jmp";
                    if (Process(operations, operationsHit)) break;
                    // revert change, it did not work
                    operations[i].op = operations[i].op == "jmp" ? "nop" : "jmp";
                }
            }

            Console.WriteLine(acc);
        }

        // return true if able to get to 1 past end of operations
        static bool Process((string op, int arg)[] operations, List<int> operationsHit)
        {
            acc = 0; // reset accumulator total
            var pos = 0; // res postition to start
            do
            {
                // We found last operation
                if (pos == operations.Length) return true;
                // We found Infinite Loop
                if (operationsHit.Contains(pos)) return false;
                
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
            } while (true);
        }
    }
}
