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
            var inputFile = @"e:\git\aoc2020\input\Day15.txt";
            var inputs = File.ReadAllText(inputFile).Split(',').Select(i => int.Parse(i)).ToList();
            var ansArray = new List<int>();
            var nextNum = inputs[inputs.Count - 1];
            
            var dic = new Dictionary<int, int>();

            for (int i = 0; i < 30000000 - 1; i++)
            {
                var foundIndex = -1;

                if (i < inputs.Count - 1)
                {
                    dic.Add(inputs[i], i);
                    continue;
                }

                else
                {
                    if (dic.ContainsKey(nextNum))
                    {
                        foundIndex = dic[nextNum];
                        dic[nextNum] = i;
                    }
                    else
                        dic.Add(nextNum, i);

                }

                //Console.WriteLine(nextNum);
                ansArray.Add(nextNum);

                // if last one added matches....
                if (foundIndex >= 0)
                    nextNum = i - foundIndex;
                else
                    nextNum = 0;


            }


            Console.WriteLine(nextNum);
            Console.ReadLine();
        }
    }
}
