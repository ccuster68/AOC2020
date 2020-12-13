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
            var inputFile = @"e:\git\aoc2020\input\Day13.txt";
            var inputs = File.ReadAllLines(inputFile);
            var busIds = inputs[1].Split(',');

            var firstBus = int.Parse(busIds[0]);
            var XsInBetween = 0;

            // Create buses and the tsDiffs from the first bus
            List<(int busId, int tsDiff)> buses = new List<(int, int)>() { (firstBus, 0) };
            var inc = 0;
            for (int i = 1; i < busIds.Length; i++)
            {

                if (busIds[i] == "x") XsInBetween++;
                else
                {
                    inc++;
                    buses.Add((int.Parse(busIds[i]), XsInBetween + inc));
                }
            }

            long tsJump = firstBus;
            long curTS = firstBus;
            // go through each bus
            // find first match, set multiple (tsJump) and go to next bus and repeat
            // At last bus you will have the first possible time that all match.
            // The key was to increase the multiple on each iteration.
            for (int i = 1; i < buses.Count; i++)
            {
                do
                {
                    if ((curTS + buses[i].tsDiff) % buses[i].busId == 0)
                    {
                        // got first match
                        tsJump *= buses[i].busId;
                        break;
                    }
                    curTS += tsJump;
                } while (true);
            }

            Console.WriteLine(curTS);
            Console.ReadLine();
        }
    }
}
