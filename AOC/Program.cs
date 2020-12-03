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
            var inputFile = @"e:\git\aoc2020\input\Day2A.txt";
            var input = File.ReadAllLines(inputFile);//.Select(y => int.Parse(y)).ToArray();

            var goodPasswords = 0;
            foreach (var i in input)
            {
                var lines = i.Split(' ');
                var least = lines[0].Split('-').Select(y => int.Parse(y)).ToArray()[0];
                var most = lines[0].Split('-').Select(y => int.Parse(y)).ToArray()[1];

                var passwordChar = lines[1][0];

                if ((lines[2][least - 1] == passwordChar && lines[2][most - 1] != passwordChar) ||
                        (lines[2][most - 1] == passwordChar && lines[2][least - 1] != passwordChar))

                    goodPasswords++;
            }

            Console.WriteLine(goodPasswords);

        }
    }
}
