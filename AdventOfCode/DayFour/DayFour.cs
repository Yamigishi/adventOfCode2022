using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class DayFour
    {

        public static void Init()
        {
            string[] lines = File.ReadAllLines(@"input.txt");
            int nbOfFullOverlap = 0;
            int nbOfAnyOverlap = 0;

            foreach (string line in lines)
            {
                var split = line.Split('-');
                var secondSplit = split[1].Split(',');

                int firstMin = Int16.Parse(split[0]);
                int firstMax = Int16.Parse(secondSplit[0]);
                int secondMin = Int16.Parse(secondSplit[1]);
                int secondMax = Int16.Parse(split[2]);


                if (checkFullOverlap(firstMin, firstMax, secondMin, secondMax))
                    nbOfFullOverlap++;
                if (checkAnyOverlap(firstMin, firstMax, secondMin, secondMax))
                    nbOfAnyOverlap++;

            }

            Console.WriteLine(nbOfFullOverlap); //part 1
            Console.WriteLine(nbOfAnyOverlap); //part 2
        }

        private static bool checkAnyOverlap(int firstMin, int firstMax, int secondMin, int secondMax)
        {
            // checking which one has the highest range
            if (firstMax - firstMin < secondMax - secondMin)
            {
                for (int i = firstMin; i <= firstMax; i++)
                {
                    if (i >= secondMin && i <= secondMax)
                        return true;
                }
            }
            else
            {
                for (int i = secondMin; i <= secondMax; i++)
                {
                    if (i >= firstMin && i <= firstMax)
                        return true;
                }
            }
            return false;
        }
        private static bool checkFullOverlap(int firstMin, int firstMax, int secondMin, int secondMax)
        {
            bool allInRange = true;
            // checking which one has the highest range
            if (firstMax - firstMin < secondMax - secondMin)
            {
                for (int i = firstMin; i <= firstMax; i++)
                {
                    // ugly
                    if (!(i >= secondMin && i <= secondMax))
                        allInRange = false;
                }
            }
            else
            {
                for (int i = secondMin; i <= secondMax; i++)
                {
                    // ugly
                    if (!(i >= firstMin && i <= firstMax))
                        allInRange = false;
                }
            }
            return allInRange;
        }
    }
}
