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
            var inputFile = @"e:\git\aoc2020\input\Day11.txt";
            // get and put input into array of operation, arg
            var rows = File.ReadAllLines(inputFile).Select(s => new StringBuilder($".{s}.")).ToList();
            //pad the seat chart
            rows.Insert(0, new StringBuilder(new string('.', rows[0].Length + 2)));
            rows.Add(new StringBuilder(new string('.', rows[0].Length + 2)));

            var seatsTaken = 0;
            var stillWorking = false;
            //  If a seat is empty (L) and there are no occupied seats adjacent to it, the seat becomes occupied.
            //  If a seat is occupied(#) and four or more seats adjacent to it are also occupied, the seat becomes empty.
            //  Otherwise, the seat's state does not change.
            do
            {
                stillWorking = false;
                var rowsClone = rows.ConvertAll(r => new StringBuilder(r.ToString())).ToList();


                for (int row = 1; row < rows.Count - 1; row++)
                {
                    for (int column = 1; column < rows[row].Length - 1; column++)
                    {
                        //L
                        if (rowsClone[row][column] == 'L')
                        {
                            if (hasNoAdjacentSeats(rowsClone, row, column))
                            {
                                rows[row][column] = '#';
                                seatsTaken++;
                                stillWorking = true;
                            }
                        }
                        //#
                        if (rowsClone[row][column] == '#')
                        {
                            if (hasFourAdjacentOccupiedSeats(rowsClone, row, column))
                            {
                                rows[row][column] = 'L';
                                seatsTaken--;
                                stillWorking = true;
                            }
                        }
                    }
                }
            } while (stillWorking);

            Console.WriteLine(seatsTaken);
        }

        private static bool hasNoAdjacentSeats(List<StringBuilder> rows, int row, int column)
        {
            if (rows[row - 1][column - 1] != '#' && rows[row - 1][column] != '#' && rows[row - 1][column + 1] != '#' &&
                rows[row][column - 1] != '#' && rows[row][column + 1] != '#' &&
                rows[row + 1][column - 1] != '#' && rows[row + 1][column] != '#' && rows[row + 1][column + 1] != '#')
                return true;

            return false;
        }

        private static bool hasFourAdjacentOccupiedSeats(List<StringBuilder> rows, int row, int column)
        {
            if ((rows[row - 1][column - 1] == '#' ? 1 : 0) + (rows[row - 1][column] == '#' ? 1 : 0) + (rows[row - 1][column + 1] == '#' ? 1 : 0) +
                (rows[row][column - 1] == '#' ? 1 : 0) + (rows[row][column + 1] == '#' ? 1 : 0) +
                (rows[row + 1][column - 1] == '#' ? 1 : 0) + (rows[row + 1][column] == '#' ? 1 : 0) + (rows[row + 1][column + 1] == '#' ? 1 : 0) >= 4)
                return true;

            return false;
        }
    }
}