using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class DayEight
    {
        public static void Init()
        {
            string[] lines = File.ReadAllLines(@"input.txt");
            int[,] grid = new int[lines[0].Length, lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    grid[i, j] = lines[i][j] - '0';
                }
            }

            int nbOfVisibleTrees = 0;
            int highestScenic = 0;
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    // part 1
                    if (CheckNorth(grid, i, j) || CheckSouth(grid, i, j) || CheckWest(grid, i, j) || CheckEast(grid, i, j))
                    {
                        nbOfVisibleTrees++;
                    }

                    //part 2
                    int scenic = ScenicNorth(grid, i, j) * ScenicSouth(grid, i, j) * ScenicWest(grid, i, j) * ScenicEast(grid, i, j);
                    if (scenic > highestScenic)
                        highestScenic = scenic;
                }
            }

            Console.WriteLine(highestScenic);
        }

        private static bool CheckNorth(int[,] grid, int x, int y)
        {
            int height = grid[x, y];
            for (int i = x - 1; i >= 0; i--)
            {
                int toCheck = grid[i, y];
                if (toCheck >= height)
                    return false;
            }
            return true;
        }
        private static bool CheckSouth(int[,] grid, int x, int y)
        {
            int height = grid[x, y];
            for (int i = x + 1; i < grid.GetLength(0); i++)
            {
                int toCheck = grid[i, y];
                if (toCheck >= height)
                    return false;
            }
            return true;
        }
        private static bool CheckWest(int[,] grid, int x, int y)
        {
            int height = grid[x, y];
            for (int i = y - 1; i >= 0; i--)
            {
                int toCheck = grid[x, i];
                if (toCheck >= height)
                    return false;
            }
            return true;
        }
        private static bool CheckEast(int[,] grid, int x, int y)
        {
            int height = grid[x, y];
            for (int i = y + 1; i < grid.GetLength(1); i++)
            {
                int toCheck = grid[x, i];
                if (toCheck >= height)
                    return false;
            }
            return true;
        }

        private static int ScenicNorth(int[,] grid, int x, int y)
        {
            int treesNb = 0;
            int height = grid[x, y];
            for (int i = x - 1; i >= 0; i--)
            {
                int toCheck = grid[i, y];
                if (toCheck < height)
                    treesNb++;
                else
                    return ++treesNb;
            }
            return treesNb;

        }
        private static int ScenicSouth(int[,] grid, int x, int y)
        {
            int treesNb = 0;
            int height = grid[x, y];
            for (int i = x + 1; i < grid.GetLength(0); i++)
            {
                int toCheck = grid[i, y];
                if (toCheck < height)
                    treesNb++;
                else
                    return ++treesNb;
            }
            return treesNb;
        }
        private static int ScenicWest(int[,] grid, int x, int y)
        {
            int treesNb = 0;
            int height = grid[x, y];
            for (int i = y - 1; i >= 0; i--)
            {
                int toCheck = grid[x, i];
                if (toCheck < height)
                    treesNb++;
                else
                    return ++treesNb;
            }
            return treesNb;

        }
        private static int ScenicEast(int[,] grid, int x, int y)
        {
            int treesNb = 0;
            int height = grid[x, y];
            for (int i = y + 1; i < grid.GetLength(1); i++)
            {
                int toCheck = grid[x, i];
                if (toCheck < height)
                    treesNb++;
                else
                    return ++treesNb;
            }
            return treesNb;

        }

    }
}
