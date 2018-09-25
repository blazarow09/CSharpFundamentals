namespace DiagonalDifference
{
    using System;
    using System.Linq;

    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var inputNumbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputNumbers[col];
                }
            }

            var firstDiagonal = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = row; col < matrix.GetLength(1);)
                {
                    firstDiagonal += matrix[row, col];
                    break;
                }
            }

            var secondDiagonal = 0;
            var elementIndex = size - 1;

            for (int row = 0 ; row < matrix.GetLength(0); row++)
            {
                for (int col = elementIndex; col < matrix.GetLength(1);)
                {
                    secondDiagonal += matrix[row, col];
                    elementIndex--;
                    break;
                }
            }

            var result = Math.Abs(firstDiagonal - secondDiagonal);

            Console.WriteLine(result);
        }
    }
}
