using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class DaySix
    {
        public static void Init()
        {
            string input = File.ReadAllText(@"input.txt");
            int nbOfUniqueCharactersRequired = 14; //part 1 value is 4

            for (int i = nbOfUniqueCharactersRequired - 1; i < input.Length; i++) { 
            
                string toTest = input.Substring(i - (nbOfUniqueCharactersRequired - 1), nbOfUniqueCharactersRequired); 
                HashSet<char> set = new HashSet<char>();

                foreach (char c in toTest)
                {
                    set.Add(c);
                }

                if (set.Count == toTest.Length) {
                    Console.WriteLine(i + 1); // since we want the position in the list and not the index it's +1
                    break;
                }
            }
        }


    }
}
