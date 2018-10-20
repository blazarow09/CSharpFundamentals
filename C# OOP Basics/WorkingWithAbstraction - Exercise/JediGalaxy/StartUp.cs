namespace P03_JediGalaxy
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static void Main()
        {
            int[] dimestions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int x = dimestions[0];
            int y = dimestions[1];

            int[,] matrix = new int[x, y];

            int value = 0;

            value = FillMatrix(x, y, matrix, value);

            string command = Console.ReadLine();

            long sum = 0;

            while (command != "Let the Force be with you")
            {
                int[] ivoS = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int[] evil = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int xEvil = evil[0];
                int yEvil = evil[1];

                CheckEvil(matrix, ref xEvil, ref yEvil);

                int xIvo = ivoS[0];
                int yIvo = ivoS[1];

                CheckIvo(matrix, ref sum, ref xIvo, ref yIvo);

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);
        }

        private static int FillMatrix(int x, int y, int[,] matrix, int value)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = value++;
                }
            }

            return value;
        }

        private static void CheckIvo(int[,] matrix, ref long sum, ref int xI, ref int yI)
        {
            while (xI >= 0 && yI < matrix.GetLength(1))
            {
                if (xI >= 0 && xI < matrix.GetLength(0) && yI >= 0 && yI < matrix.GetLength(1))
                {
                    sum += matrix[xI, yI];
                }

                yI++;
                xI--;
            }
        }

        private static void CheckEvil(int[,] matrix, ref int xE, ref int yE)
        {
            while (xE >= 0 && yE >= 0)
            {
                if (xE >= 0 && xE < matrix.GetLength(0) && yE >= 0 && yE < matrix.GetLength(1))
                {
                    matrix[xE, yE] = 0;
                }
                xE--;
                yE--;
            }
        }
    }
}