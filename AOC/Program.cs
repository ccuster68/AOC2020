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
                var least = lines[0].Split('-').Select(y=>int.Parse(y)).ToArray()[0];
                var most = lines[0].Split('-').Select(y => int.Parse(y)).ToArray()[1];

                var passwordChar = lines[1][0];

                var charCount = lines[2].Count(y => y == passwordChar);


                if (charCount >= least && charCount <= most) goodPasswords++;
            }

            Console.WriteLine(goodPasswords);
            
        }
    }
}
