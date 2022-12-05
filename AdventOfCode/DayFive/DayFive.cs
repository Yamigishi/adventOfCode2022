using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class DayFive
    {
        public static void Init()
        {
            // I'm too lazy to parse the file i'm just writing the initial list right here idc how ugly it is
            List<List<char>> list = new List<List<char>>();
            list.Add(new List<char> { 'F', 'H', 'B', 'V', 'R', 'Q', 'D', 'P' });
            list.Add(new List<char> { 'L', 'D', 'Z', 'Q', 'W', 'V' });
            list.Add(new List<char> { 'H', 'L', 'Z', 'Q', 'G', 'R', 'P', 'C' });
            list.Add(new List<char> { 'R', 'D', 'H', 'F', 'J', 'V', 'B' });
            list.Add(new List<char> { 'Z', 'W', 'L', 'C' });
            list.Add(new List<char> { 'J', 'R', 'P', 'N', 'T', 'G', 'V', 'M' });
            list.Add(new List<char> { 'J', 'R', 'L', 'V', 'M', 'B', 'S' });
            list.Add(new List<char> { 'D', 'P', 'J' });
            list.Add(new List<char> { 'D', 'C', 'N', 'W', 'V' });

            string[] lines = File.ReadAllLines(@"input.txt");
            foreach (string line in lines)
            {
                string l = line;
                int nbOfCrates = 0;
                int initialStack = 0;
                int destinationStack = 0;

                l = l.Replace("move ", "");
                l = l.Replace(" from ", " ");
                l = l.Replace(" to ", " ");

                string[] numbers = l.Split(' ');
                nbOfCrates = int.Parse(numbers[0]);
                initialStack = int.Parse(numbers[1]);
                destinationStack = int.Parse(numbers[2]);


                //part 1
                /*for (int i = 0; i < nbOfCrates; i++)
                {
                    char toMove = list[initialStack - 1][list[initialStack - 1].Count - 1];
                    list[destinationStack - 1].Add(toMove);
                    list[initialStack - 1].RemoveAt(list[initialStack - 1].Count - 1);
                }*/

                //part 2
                List<char> toMove = new List<char>();
                foreach (var item in list[initialStack - 1].Skip( list[initialStack - 1].Count - nbOfCrates))
                {
                    toMove.Add(item);
                }
                list[destinationStack - 1].AddRange(toMove);
                list[initialStack - 1].RemoveRange(list[initialStack - 1].Count - nbOfCrates, nbOfCrates);
            }

            foreach (var item in list)
            {
                Console.WriteLine(item[item.Count - 1]);
            }
        }
    }
}
