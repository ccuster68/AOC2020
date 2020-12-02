using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = @"e:\git\aoc2020\input\Day1A.txt";
            var input = File.ReadAllLines(inputFile).Select(y => int.Parse(y)).ToArray();
            var minNum = input.Min();
            var maxNum = input.Max();

            for (int i = 0; i < input.Length - 2; i++)
            {
                for (int j = i + 1; j < input.Length - 1; j++)
                {
                    if (input[i] + input[j] + minNum > 2020)
                        continue;
                    for (int k = j + 1; k < input.Length; k++)
                    {
                        if (input[i] + input[j] + input[k] == 2020)
                            Console.WriteLine(input[i] * input[j] * input[k]);
                    }
                }
            }

        }
    }
}
