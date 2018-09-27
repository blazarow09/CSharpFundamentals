namespace TargetPractice
{
    using System;
    using System.Linq;

    class TargetPractice
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = sizes[0];
            var cols = sizes[1];

            char[][] matrix = new char[rows][];

            var snake = Console.ReadLine()
                .ToCharArray();

            var count = 0;

            for (int row = rows - 1; row >= 0; row--)
            {
                matrix[row] = new char[cols];
                for (int col = cols - 1; col >= 0; col--)
                {
                    if (count == snake.Length)
                    {
                        count = 0;
                    }

                    matrix[row][col] = snake[count];
                    count++;
                }
            }

            var cmdArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var impactRow = cmdArgs[0];
            var impactCol = cmdArgs[1];
            var radius = cmdArgs[2];


            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (IsShooted(row, col, impactRow, impactCol, radius))
                    {
                        matrix[row][col] = ' ';
                    }
                }
            }

            for (int col = 0; col < matrix[0].Length; col++)
            {
                for (int row = matrix.Length - 1; row >= 0; row--)
                {
                    if (matrix[row][col] == ' ' 
                        && matrix[row - 1][col] != ' ')
                    {
                        CellFalling(matrix, row, col);
                    }
                }
            }
        }

        private static bool IsShooted(int row, int col, int impactRow, int impactCol, int radius)
        {
            double distance = Math.Sqrt((row - impactRow) * (row - impactRow));
            return distance <= radius;
        }

        private static void CellFalling(char[][] matrix, int row, int col)
        {
            while (row < matrix.Length)
            {
                if (matrix[row][col] == ' ')
                {
                    char temporary = matrix[row - 1][col];
                    matrix[row - 1][col] = matrix[row][col];
                    matrix[row][col] = temporary;
                    row++;
                }
                else
                {
                    return;
                }
            }
        }
    }
}
