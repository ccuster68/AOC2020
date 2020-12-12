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
        static (int h, int v) waypoint = (10, 1);
        static int h = 0;
        static int v = 0;
        static void Main(string[] args)
        {
            var inputFile = @"e:\git\aoc2020\input\Day12.txt";
            // get and put input into array of operation, arg
            var inputs = File.ReadAllLines(inputFile);

            foreach (var line in inputs)
            {
                // get the value
                var value = int.Parse(line.Substring(1));
                switch (line[0])
                {
                    case 'L':
                    case 'R':
                        setWaypoint(line);
                        break;
                    case 'N':
                        waypoint.v += value;
                        break;
                    case 'S':
                        waypoint.v -= value;
                        break;
                    case 'E':
                        waypoint.h += value;
                        break;
                    case 'W':
                        waypoint.h -= value;
                        break;
                    case 'F':
                        // move ship towards waypoint
                        h += value * waypoint.h;
                        v += value * waypoint.v;
                        break;
                }
            }
            Console.WriteLine(Math.Abs(h) + Math.Abs(v));
        }

        static void setWaypoint(string line)
        {
            int tempH;
            switch (line)
            {
                case "L270":
                case "R90":
                    tempH = waypoint.v;
                    waypoint.v = -waypoint.h;
                    waypoint.h = tempH;
                    break;
                case "L180":
                case "R180":
                    tempH = -waypoint.h;
                    waypoint.v = -waypoint.v;
                    waypoint.h = -waypoint.h;
                    break;
                case "L90":
                case "R270":
                    var newH = -waypoint.v;
                    waypoint.v = waypoint.h;
                    waypoint.h = newH;
                    break;
            }

        }

    }
}