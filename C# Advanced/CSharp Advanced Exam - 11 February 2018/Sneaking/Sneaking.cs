namespace Sneaking
{
    using System;
    using System.Linq;

    class Sneaking
    {
        static int playerRow;
        static int playerCol;
        static char[] directionArgs;
        static char[][] jaggedArray;

        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());

            jaggedArray = new char[rows][];

            FillJaggedArray();

            directionArgs = Console.ReadLine()
                .ToCharArray();

            foreach (var move in directionArgs)
            {
                UpdateEnemies();

                CheckEnemies();

                MoveSam(move);

                CheckNikoladze();
            }
        }

        private static void FillJaggedArray()
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                var input = Console.ReadLine();

                jaggedArray[row] = new char[input.Length];

                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    jaggedArray[row][col] = input[col];

                    if (jaggedArray[row][col] == 'S')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
        }

        private static void UpdateEnemies()
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    if (jaggedArray[row][col] == 'b')
                    {
                        if (col == jaggedArray[row].Length - 1)
                        {
                            jaggedArray[row][col] = 'd';
                        }
                        else
                        {
                            jaggedArray[row][col] = '.';
                            jaggedArray[row][++col] = 'b';
                        }
                    }
                    else if (jaggedArray[row][col] == 'd')
                    {
                        if (col == 0)
                        {
                            jaggedArray[row][col] = 'b';
                        }
                        else
                        {
                            jaggedArray[row][col] = '.';
                            jaggedArray[row][col - 1] = 'd';
                        }
                    }
                }

            }
        }

        private static void CheckEnemies()
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                if (jaggedArray[row].Contains('b') && jaggedArray[row].Contains('S'))
                {
                    if (Array.IndexOf(jaggedArray[row], 'b') < Array.IndexOf(jaggedArray[row], 'S'))
                    {
                        jaggedArray[row][Array.IndexOf(jaggedArray[row], 'S')] = 'X';
                        Console.WriteLine($"Sam died at {row}, {Array.IndexOf(jaggedArray[row], 'X')}");
                        Print();
                    }
                }
                else if (jaggedArray[row].Contains('d') && jaggedArray[row].Contains('S'))
                {
                    if (Array.IndexOf(jaggedArray[row], 'd') > Array.IndexOf(jaggedArray[row], 'S'))
                    {
                        jaggedArray[row][Array.IndexOf(jaggedArray[row], 'S')] = 'X';
                        Console.WriteLine($"Sam died at {row}, {Array.IndexOf(jaggedArray[row], 'X')}");
                        Print();
                    }
                }
            }
        }

        private static void MoveSam(char move)
        {
            switch (move)
            {
                case 'U':
                    jaggedArray[playerRow][playerCol] = '.';
                    jaggedArray[--playerRow][playerCol] = 'S';

                    break;
                case 'D':
                    jaggedArray[playerRow][playerCol] = '.';
                    jaggedArray[++playerRow][playerCol] = 'S';
                    break;
                case 'L':
                    jaggedArray[playerRow][playerCol] = '.';
                    jaggedArray[playerRow][--playerCol] = 'S';
                    break;
                case 'R':
                    jaggedArray[playerRow][playerCol] = '.';
                    jaggedArray[playerRow][++playerCol] = 'S';
                    break;
                default:
                    break;
            }
        }

        private static void CheckNikoladze()
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                if (jaggedArray[row].Contains('N') && jaggedArray[row].Contains('S'))
                {
                    jaggedArray[row][Array.IndexOf(jaggedArray[row], 'N')] = 'X';
                    Console.WriteLine($"Nikoladze killed!");
                    Print();
                }
            }
        }

        private static void Print()
        {
            foreach (var row in jaggedArray)
            {
                Console.WriteLine(String.Join("", row));
            }
            Environment.Exit(0);
        }
    }
}
