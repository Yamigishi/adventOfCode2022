using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class DayOne
    {
        public static void Init()
        {
            string[] lines = File.ReadAllLines(@"input.txt");
            List<long> calories = new List<long>();
            int i = 0;

            foreach (string line in lines)
            {
                if (line != "")
                {
                    if (calories.Count > 1)
                        calories[i] += Int64.Parse(line);
                    else
                        calories.Add(Int64.Parse(line));
                }
                else
                    i++;
            }

            calories.Sort();
            long top3 = calories[calories.Count - 1] + calories[calories.Count - 2] + calories[calories.Count - 3];

            Console.WriteLine(calories[calories.Count - 1]); //part 1
            Console.WriteLine(top3); //part 2
        }
    }
}
