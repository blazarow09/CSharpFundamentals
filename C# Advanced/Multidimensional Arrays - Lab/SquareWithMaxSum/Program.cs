using System;
using System.Linq;

namespace Multidimensional_Arrays_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndColumns = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.None)
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

            int rowIndex = 0, colIndex = 0;
            int sum = 0;

            for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1) - 1; cols++)
                {
                    var tempSum = matrix[rows, cols] + matrix[rows, cols + 1]
                        + matrix[rows + 1, cols] + matrix[rows + 1, cols + 1];

                    if (tempSum > sum)
                    {
                        sum = tempSum;
                        rowIndex = rows;
                        colIndex = cols;
                    }
                }
            }

            Console.WriteLine(matrix[rowIndex, colIndex] + " " + matrix[rowIndex, colIndex + 1]);
            Console.WriteLine(matrix[rowIndex + 1, colIndex] +  " " +matrix[rowIndex + 1, colIndex + 1]);
            Console.WriteLine(sum);
        }
    }
}
