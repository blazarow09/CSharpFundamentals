namespace _2x2SquaresInMatrix
{
    using System;
    using System.Linq;

    class _2x2SquaresInMatrix
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = sizes[0];
            var cols = sizes[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var inputLetters = Console.ReadLine()
                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                     .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputLetters[col];
                }
            }

            var isEqual = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1]
                        && matrix[row, col] == matrix[row + 1, col]
                        && matrix[row + 1, col] == matrix[row + 1, col + 1]
                        && matrix[row + 1, col + 1] == matrix[row, col + 1])
                    {
                        isEqual++;
                    }
                }
            }
            Console.WriteLine(isEqual);
        }
    }
}
