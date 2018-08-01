using System;
using System.Linq;

namespace Multidimensional_Arrays_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndColumns = Console.ReadLine()
                .Split(new string[] {", " },StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();
            int[,] matrix = new int[rowsAndColumns[0], rowsAndColumns[1]];

            for (int rows = 0; rows < rowsAndColumns[0]; rows++)
            {
                var rowValues = Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.None)
                    .Select(int.Parse)
                    .ToArray();

                for (int cols = 0; cols < rowsAndColumns[1]; cols++)
                {
                    matrix[rows, cols] = rowValues[cols];
                }
            }

            int sum = 0;

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    sum += matrix[rows, cols];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}
