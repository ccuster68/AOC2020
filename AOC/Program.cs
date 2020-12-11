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
            rows.Insert(0, new StringBuilder(new string('.', rows[0].Length)));
            rows.Add(new StringBuilder(new string('.', rows[0].Length)));

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
                            if (hasFiveAdjacentOccupiedSeats(rowsClone, row, column))
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
            var r = row;
            var c = column;
            // visible, go off in 8 directions.
            // 1. up left.
            while (r > 0 && c > 0)
            {   
                var test = rows[--r][--c];
                if (test == '#') return false;
                if (test == 'L') break;
            } ;
            r = row;
            c = column;
            // 2. up
            while (r > 0)
            {
                var test = rows[--r][c];
                if (test == '#') return false;
                if (test == 'L') break;
            } ;
            r = row;
            c = column;
            // 3. up right
            while (r > 0 && c < rows[0].Length - 2)
            {
                var test = rows[--r][++c];
                if (test == '#') return false;
                if (test == 'L') break;
            } ;
            r = row;
            c = column;
            // 4. left
            while (c > 0)
            {
                var test = rows[r][--c];
                if (test == '#') return false;
                if (test == 'L') break;
            } ;
            r = row;
            c = column;
            // 5. right
            while (c < rows[0].Length - 2)
            {
                var test = rows[r][++c];
                if (test == '#') return false;
                if (test == 'L') break;
            } ;
            r = row;
            c = column;
            // 6. down left
            while (r < rows.Count - 2 && c > 0)
            {
                var test = rows[++r][--c];
                if (test == '#') return false;
                if (test == 'L') break;
            } ;
            r = row;
            c = column;
            // 7. down
            while (r < rows.Count - 2)
            {
                var test = rows[++r][c];
                if (test == '#') return false;
                if (test == 'L') break;
            };
            r = row;
            c = column;
            // 8. down right
            while (r < rows.Count - 2 && c < rows[0].Length - 2)
            {
                var test = rows[++r][++c];
                if (test == '#') return false;
                if (test == 'L') break;
            };


            return true;
        }

        private static bool hasFiveAdjacentOccupiedSeats(List<StringBuilder> rows, int row, int column)
        {
            var visibleOccupiedSeats = 0;
            var r = row;
            var c = column;
            // visible, go off in 8 directions.
            // 1. up left.
            while (r > 0 && c > 0)
            {
                var test = rows[--r][--c];
                if (test == '#')
                {
                    if (++visibleOccupiedSeats >= 5) return true;
                    break;
                }
                else if (test == 'L') break;
            };
            r = row;
            c = column;
            // 2. up
            while (r > 0)
            {
                var test = rows[--r][c];
                if (test == '#')
                {
                    if (++visibleOccupiedSeats >= 5) return true;
                    break;
                }
                else if (test == 'L') break;
            };
            r = row;
            c = column;
            // 3. up right
            while (r > 0 && c < rows[0].Length - 2)
            {
                var test = rows[--r][++c];
                if (test == '#')
                {
                    if (++visibleOccupiedSeats >= 5) return true;
                    break;
                }
                else if (test == 'L') break;
            };
            r = row;
            c = column;
            // 4. left
            while (c > 0)
            {
                var test = rows[r][--c];
                if (test == '#')
                {
                    if (++visibleOccupiedSeats >= 5) return true;
                    break;
                }
                else if (test == 'L') break;
            };
            r = row;
            c = column;
            // 5. right
            while (c < rows[0].Length - 2)
            {
                var test = rows[r][++c];
                if (test == '#')
                {
                    if (++visibleOccupiedSeats >= 5) return true;
                    break;
                }
                else if (test == 'L') break;
            };
            r = row;
            c = column;
            // 6. down left
            while (r < rows.Count - 2 && c > 0)
            {
                var test = rows[++r][--c];
                if (test == '#')
                {
                    if (++visibleOccupiedSeats >= 5) return true;
                    break;
                }
                else if (test == 'L') break;
            };
            r = row;
            c = column;
            // 7. down
            while (r < rows.Count - 2)
            {
                var test = rows[++r][c];
                if (test == '#')
                {
                    if (++visibleOccupiedSeats >= 5) return true;
                    break;
                }
                else if (test == 'L') break;
            };
            r = row;
            c = column;
            // 8. down right
            while (r < rows.Count - 2 && c < rows[0].Length - 2)
            {
                var test = rows[++r][++c];
                if (test == '#')
                {
                    if (++visibleOccupiedSeats >= 5) return true;
                    break;
                }
                else if (test == 'L') break;
            };

            return false;
        }
    }
}