namespace DiagonalDifference
{
    using System;
    using System.Linq;

    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] square = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] rowsValue = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    square[row, col] = rowsValue[col];
                }
            }

            var firstDiagonalSum = 0;
            var secondDiagonalSum = 0;

            for (int i = 0; i < size; i++)
            {
                firstDiagonalSum += square[i, i];
            }

            for (int i = 0; i < size; i++)
            {
                secondDiagonalSum += square[i, size - 1 - i];
            }

            var result = Math.Abs(firstDiagonalSum - secondDiagonalSum);

            Console.WriteLine(result);
        }
    }
}
