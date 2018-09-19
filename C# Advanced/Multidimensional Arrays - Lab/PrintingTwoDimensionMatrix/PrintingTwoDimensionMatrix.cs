using System;

namespace PrintingTwoDimensionMatrix
{
    class PrintingTwoDimensionMatrix
    {
        static void Main(string[] args)
        {
            int[,] matrix =
            {
                {1, 2},
                {3, 4},
                {5, 6},
                {7, 8}
            };

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    Console.WriteLine(matrix[rows, cols]);
                }
                Console.WriteLine();
            }
        }
    }
}
