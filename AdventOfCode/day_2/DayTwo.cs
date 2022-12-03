namespace AdventOfCode
{
    class DayTwo
    {
        public static void Init()
        {
            long score = 0;
            string[] lines = File.ReadAllLines(@"input.txt");

            foreach (string line in lines)
            {
                char opponentPlay = line[0];
                char myPlay = line[2];
                myPlay = determinatePlay(opponentPlay, myPlay);

                score += addPlayScore(myPlay);
                score += addResultScore(opponentPlay, myPlay);
            }

            Console.WriteLine(score);
        }

        static char determinatePlay(char opponentPlay, char endCondition)
        {
            switch (endCondition)
            {
                case 'X':
                    if (opponentPlay == 'A')
                        return 'Z';
                    else if (opponentPlay == 'B')
                        return 'X';
                    else
                        return 'Y';
                case 'Y':
                    if (opponentPlay == 'A')
                        return 'X';
                    else if (opponentPlay == 'B')
                        return 'Y';
                    else
                        return 'Z';
                case 'Z':
                    if (opponentPlay == 'A')
                        return 'Y';
                    else if (opponentPlay == 'B')
                        return 'Z';
                    else
                        return 'X';
                default:
                    return ' ';
            }
        }

        static long addPlayScore(char myPlay)
        {
            switch (myPlay)
            {
                case 'X':
                    return 1;
                case 'Y':
                    return 2;
                case 'Z':
                    return 3;
                default:
                    return 0;
            }
        }
        static long addResultScore(char opponentPlay, char myPlay)
        {
            switch (myPlay)
            {
                case 'X':
                    if (opponentPlay == 'A')
                        return 3;
                    else if (opponentPlay == 'B')
                        return 0;
                    else
                        return 6;
                case 'Y':
                    if (opponentPlay == 'A')
                        return 6;
                    else if (opponentPlay == 'B')
                        return 3;
                    else
                        return 0;
                case 'Z':
                    if (opponentPlay == 'A')
                        return 0;
                    else if (opponentPlay == 'B')
                        return 6;
                    else
                        return 3;
                default:
                    return 0;
            }
        }
    }
}