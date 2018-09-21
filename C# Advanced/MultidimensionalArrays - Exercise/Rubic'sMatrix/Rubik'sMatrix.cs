namespace Rubic_sMatrix
{
    using System;
    using System.Linq;

    class RubicsMatrix
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rowSize = sizes[0];
            var colSize = sizes[1];

            var matrix = new int[rowSize, colSize];

            var bluePrint = new int[rowSize, colSize];

            var matrixValue = 1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {

                    matrix[row, col] = matrixValue;
                    matrixValue++;
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    bluePrint[row, col] = matrix[row, col];
                }
            }

            int N = int.Parse(Console.ReadLine());

            for (int index = 0; index < N; index++)
            {
                var cmdArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var rowOrCol = int.Parse(cmdArgs[0]);
                var direction = cmdArgs[1];
                var moves = int.Parse(cmdArgs[2]);

                if (direction == "up" || direction == "down")
                {
                    ShiftColumn(matrix, direction, index, moves);
                }
                else if (direction == "right" || direction == "left")
                {
                    ShiftRow(matrix, direction, index, moves);
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] != bluePrint[row, col])
                    {
                        EqualizeValue(matrix, bluePrint, ref row, ref col);
                    }
                    else
                    {
                        Console.WriteLine("No swap required");
                    }
                }
            }
        }

        private static void EqualizeValue(int[,] matrix, int[,] bluePrint, ref int coordX, ref int coordY)
        {
            var swap = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == bluePrint[coordX, coordY])
                    {
                        Console.WriteLine($"Swap ({coordX}, {coordY}) with ({row}, {col})");

                        swap = matrix[coordX, coordY];
                        matrix[coordX, coordY] = matrix[row, col];
                        matrix[row, col] = swap;
                        return;
                    }
                }
            }
        }

        private static void ShiftRow(int[,] matrix, string direction, int index, int moves)
        {
            var last = 0;

            if (direction == "left")
            {
                for (int row = 0; row < moves % matrix.GetLength(1); row++)
                {
                    last = matrix[index, 0];

                    for (int col = 0, i = 1; col < matrix.GetLength(1) -1; col++, i++)
                    {
                        matrix[index, col] = matrix[index, i];
                    }
                    matrix[index, matrix.GetLength(1) - 1] = last;
                }
            }
            else if (direction == "right")
            {
                for (int row = 0; row < moves % matrix.GetLength(1); row++)
                {
                    last = matrix[index, matrix.GetLength(1) - 1];

                    for (int col = matrix.GetLength(1) - 1, i = matrix.GetLength(1) - 2; col >= 1; col--, i--)
                    {
                        matrix[index, col] = matrix[index, i];
                    }
                    matrix[index, 0] = last;
                }
            }
        }

        private static void ShiftColumn(int[,] matrix, string direction, int index, int moves)
        {
            var last = 0;
            if (direction == "down")
            {
                for (int row = 0; row < moves % matrix.GetLength(0); row++)
                {
                    last = matrix[matrix.GetLength(0) - 1, index];
                    for (int col = matrix.GetLength(0) - 1, i = matrix.GetLength(0) - 2; col >= 1; col--, i--)
                    {
                        matrix[col, index] = matrix[i, index];
                    }
                    matrix[0, index] = last;
                }
            }
            else if (direction == "up")
            {
                for (int row = 0; row < moves % matrix.GetLength(0); row++)
                {
                    last = matrix[0, index];
                    for (int col = 0, i = 1; col < matrix.GetLength(0) - 1; col++, i++)
                    {
                        matrix[col, index] = matrix[i, index];
                    }
                    matrix[matrix.GetLength(0) - 1, index] = last;
                }
            }
        }
    }
}
