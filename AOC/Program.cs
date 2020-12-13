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
            var inputFile = @"e:\git\aoc2020\input\Day13test.txt";
            var inputs = File.ReadAllLines(inputFile);
            var earliestTime = int.Parse(inputs[0]);
            var busIds = inputs[1].Split(',');

            var firstBus = int.Parse(busIds[0]);
            var XsInBetween = 0;
            List<(int busId, int x)> buses = new List<(int busId, int tsDiff)>() { (firstBus, 0) };

            var inc = 0;
            for (int i = 1; i < busIds.Length; i++)
            {
                
                if (busIds[i] == "x") XsInBetween++;
                else
                {
                    inc++;
                    buses.Add((int.Parse(busIds[i]), XsInBetween+inc));
                }
            }
            var found = false;
            long firstBusTS = 0;
            do
            {
                firstBusTS += firstBus;

                long newTS = firstBusTS;
                for (int i = 1; i < buses.Count; i++)
                {
                    newTS += buses[i].x + 1;
                    if (newTS % buses[i].busId != 0)
                    {
                        break;
                    }
                    // if we make it here and we are on last buss we found it
                    if (i == buses.Count - 1) found = true;
                }
            } while (!found);
            Console.WriteLine(firstBusTS);
            Console.ReadLine();
        }
    }
}
