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
            var inputFile = @"e:\git\aoc2020\input\Day12.txt";
            // get and put input into array of operation, arg
            var inputs = File.ReadAllLines(inputFile);
            List<(string dir, int value)> lines = inputs.Select(s => (s.Substring(0, 1), int.Parse(s.Substring(1)))).ToList();

            // Action N means to move north by the given value.
            // Action S means to move south by the given value.
            // Action E means to move east by the given value.
            // Action W means to move west by the given value.
            // Action L means to turn left the given number of degrees.
            // Action R means to turn right the given number of degrees.
            // Action F means to move forward by the given value in the direction the ship is currently facing.

            var h = 0;
            var v = 0;
            var d = 0;
            var currentDir = 0;

            foreach (var line in lines)
            {
                switch (line.dir)
                {
                    case "L":
                        currentDir = getDir(currentDir, -line.value);
                        break;
                    case "R":
                        currentDir = getDir(currentDir, line.value);
                        break;
                    case "N":
                        v += line.value;
                        break;
                    case "S":
                        v -= line.value;
                        break;
                    case "E":
                        h += line.value;
                        break;
                    case "W":
                        h -= line.value;
                        break;
                    case "F":
                        switch (currentDir)
                        {
                            case 270:
                                v += line.value;
                                break;
                            case 90:
                                v -= line.value;
                                break;
                            case 0:
                                h += line.value;
                                break;
                            case 180:
                                h -= line.value;
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(Math.Abs(h)+Math.Abs(v));
        }

        static int getDir(int currentDir, int change)
        {
            currentDir += change;
            if (currentDir >= 360) return currentDir - 360;
            if (currentDir < 0) return currentDir + 360;
            return currentDir;
        }
    }
}