using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class DayThree
    {

        public static void Init()
        {
            string[] lines = File.ReadAllLines(@"input.txt");
            int partOne = 0;
            int partTwo = 0;
            int fakedex = 1; //fakedex because the real index is -1 this value
            List<string> group = new List<string>();


            foreach (string line in lines)
            {
                string firstCompartment = line.Substring(0, line.Length / 2);
                string secondCompartment = line.Substring(line.Length / 2, line.Length / 2);

                char common = firstCompartment.Intersect(secondCompartment).FirstOrDefault();

                partOne += CalculateCharValue(common);

                group.Add(line);

                if (fakedex % 3 == 0)
                {
                    char c = FindCommonChar(group);
                    partTwo += CalculateCharValue(c);
                    group.Clear();
                }
                fakedex++;
            }

            Console.WriteLine(partOne); //part 1
            Console.WriteLine(partTwo); //part 2

        }

        private static int CalculateCharValue(char c)
        {
            if ((int)c >= 65 && (int)c <= 90)
                return (int)c- 38;
            else
                return (int)c - 96;
        }

        private static char FindCommonChar(List<string> strings)
        {
            //this code obviously only works correctly in the context of the calendar AKA only 3 items in the list and only one common character for all of them
            string one = strings[0];
            string two = strings[1]; 
            string three = strings[2];
            char common = ' ';

            IEnumerable<char> commonsOneAndTwo = one.Intersect(two);
            IEnumerable<char> commonTwoAndThree = two.Intersect(three);
            IEnumerable<char> commonOneAndThree = one.Intersect(three);

            foreach (char c in commonOneAndThree)
            {
                if (commonsOneAndTwo.Contains(c) && commonTwoAndThree.Contains(c))
                    common = c;
            }

            return common;
        }
    }
}
