namespace Miner
{
    using System;
    using System.Linq;

    class Miner
    {
        static char[][] jaggedArray;
        static string[] directionArgs;
        static int playerRow;
        static int playerCol;
        static int coalCount;
        static int coalCollected;
        static int directionCount;

        static void Main(string[] args)
        {
            var dimension = int.Parse(Console.ReadLine());

            directionArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            jaggedArray = new char[dimension][];

            FillJaggedArray();

            MoveMiner(dimension);
        }

        private static void MoveMiner(int dimension)
        {
            foreach (var move in directionArgs)
            {
                directionCount++;

                switch (move)
                {
                    case "up":

                        if (playerRow > 0)
                        {
                            playerRow--;
                        }
                        break;
                    case "left":

                        if (playerCol > 0)
                        {
                            playerCol--;
                        }
                        break;
                    case "right":

                        if (playerCol < dimension - 1)
                        {
                            playerCol++;
                        }
                        break;
                    case "down":

                        if (playerRow < dimension - 1)
                        {
                            playerRow++;
                        }
                        break;

                }

                if (jaggedArray[playerRow][playerCol] == 'c')
                {
                    coalCollected++;
                    jaggedArray[playerRow][playerCol] = '*';
                }
                else if (jaggedArray[playerRow][playerCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({playerRow}, {playerCol})");
                    Environment.Exit(0);
                }

                if (coalCollected == coalCount)
                {
                    Console.WriteLine($"You collected all coals! ({playerRow}, {playerCol})");
                    Environment.Exit(0);
                }

                if (directionCount == directionArgs.Count())
                {
                    Console.WriteLine($"{coalCount - coalCollected} coals left. ({playerRow}, {playerCol})");
                    Environment.Exit(0);
                }

            }
        }

        private static void FillJaggedArray()
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                var line = Console.ReadLine()
                    .Where(l => l != ' ')
                    .ToArray();

                jaggedArray[row] = new char[line.Length];

                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    jaggedArray[row][col] = line[col];

                    if (jaggedArray[row][col] == 's')
                    {
                        playerRow = row;
                        playerCol = col;
                    }

                    if (jaggedArray[row][col] == 'c')
                    {
                        coalCount++;
                    }
                }
            }
        }
    }
}
