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
            var inputs = File.ReadAllLines(@"e:\git\aoc2020\input\Day16.txt").ToList();

            var list = new List<int>();
            foreach (var input in inputs.Where(i => i.Contains(" or ")).ToList())
            {
                var firstIdx = input.IndexOf(": ") + 2;
                var secondIdx = input.IndexOf("-");
                var first = int.Parse(input.Substring(firstIdx, secondIdx - firstIdx));
                firstIdx = input.IndexOf("-") + 1;
                secondIdx = input.IndexOf(" or ");
                var second = int.Parse(input.Substring(firstIdx, secondIdx - firstIdx));
                firstIdx = input.IndexOf(" or ") + 4;
                secondIdx = input.IndexOf("-", firstIdx);
                var third = int.Parse(input.Substring(firstIdx, secondIdx - firstIdx));
                firstIdx = input.IndexOf("-", secondIdx) + 1;
                var fourth = int.Parse(input.Substring(firstIdx));

                for (int i = first; i < second + 1; i++)
                {
                    if (!list.Contains(i)) list.Add(i);
                }

                for (int i = third; i < fourth + 1; i++)
                {
                    if (!list.Contains(i)) list.Add(i);
                }
            }
            list.Sort();

            var ans = 1L;

            bool found = false;
            var myTicket = new int[inputs.Where(i => i.Contains(" or ")).Count()];
            
            var goodTickets = new List<string>();
            var noOrs = inputs.Where(i => !i.Contains(" or ")).ToList();
            for (int i = 0; i < noOrs.Count; i++)
            {
                var input = noOrs[i];
                if (input.Contains("your ticket:"))
                {
                    goodTickets.Add(noOrs[i + 1]);
                    myTicket = noOrs[i + 1].Split(',').Select(n=>int.Parse(n)).ToArray();
                }
                    

                if (!found)
                {
                    if (input != "nearby tickets:")
                    {
                        continue;
                    }
                    else
                    {
                        found = true;
                        continue;
                    }
                }

                var good = true;
                foreach (var num in input.Split(',').Select(n => int.Parse(n)).ToArray())
                {
                    if (!list.Contains(num))
                    {
                        good = false;
                        break;
                    }
                }
                if (good)
                    goodTickets.Add(input);
            }

            Dictionary<string, ((int range1Start, int range1End) Range1, (int range2Start, int range2End) Range2)> dicCategories = new Dictionary<string, ((int range1Start, int range1End), (int range2Start, int range2End))>();
            // now set up categories
            foreach (var input in inputs.Where(i => i.Contains(" or ")).ToList())
            {
                var firstIdx = input.IndexOf(": ") + 2;
                var secondIdx = input.IndexOf("-");
                var first = int.Parse(input.Substring(firstIdx, secondIdx - firstIdx));
                firstIdx = input.IndexOf("-") + 1;
                secondIdx = input.IndexOf(" or ");
                var second = int.Parse(input.Substring(firstIdx, secondIdx - firstIdx));
                firstIdx = input.IndexOf(" or ") + 4;
                secondIdx = input.IndexOf("-", firstIdx);
                var third = int.Parse(input.Substring(firstIdx, secondIdx - firstIdx));
                firstIdx = input.IndexOf("-", secondIdx) + 1;
                var fourth = int.Parse(input.Substring(firstIdx));

                var key = input.Substring(0, input.IndexOf(":"));
                dicCategories.Add(key, ((first, second), (third, fourth)));

            }

            // I have dicCategories with ranges and list of good tickets.  
            // now identify the row with the dicCategory
            var dicCatCol = new Dictionary<string, List<int>>();
            
            foreach (var cat in dicCategories)//.Where(c=>c.Key.StartsWith("departure")))
            {
                for (int column = 0; column < dicCategories.Count; column++)
                {
                    //Console.WriteLine($"************COLUMN {column} *******************************");
                    var stillGood = true;
                    // go through columns of tickets and if all fit, then update the cat.column
                    for (int gt = 0; gt < goodTickets.Count; gt++)
                    {
                        var gtRowValue = goodTickets[gt].Split(',').Select(v => int.Parse(v)).ToArray()[column];
                        //Console.WriteLine($"{gtRowValue}: {cat.Value.Range1.range1Start}-{cat.Value.Range1.range1End}, {cat.Value.Range2.range2Start}-{cat.Value.Range2.range2End}");
                        if (gtRowValue<cat.Value.Range1.range1Start || gtRowValue>cat.Value.Range2.range2End ||(gtRowValue>cat.Value.Range1.range1End && gtRowValue <cat.Value.Range2.range2Start))
                        {
                            // found bad column
                            stillGood = false;
                            break;
                        }
                        
                    }
                    if (stillGood)
                    {
                        //ans *= myTicket[column];
                        var toAdd = new List<int>();
                        toAdd.Add(column);
                        if (dicCatCol.ContainsKey(cat.Key))
                        {
                            toAdd.AddRange(dicCatCol[cat.Key]);
                            dicCatCol[cat.Key] = toAdd;
                        }
                        else
                            dicCatCol.Add(cat.Key, toAdd);

                        continue;
                    }


                }
            }

            var dicCatOneCol = new Dictionary<int, string>();

            for (int i = 1; i < 21; i++)
            {
                var dic = dicCatCol.Where(d => d.Value.Count == i).First();
                foreach (var item in dic.Value)
                {
                    if (dicCatOneCol.ContainsKey(item)) continue;
                    else dicCatOneCol.Add(item, dic.Key);
                }
                
            }

            foreach (var item in dicCatOneCol.Where(d=>d.Value.StartsWith("departure")))
            {
                ans *= myTicket[item.Key];
            }




            Console.WriteLine(ans);
            Console.ReadLine();
        }
    }
}
