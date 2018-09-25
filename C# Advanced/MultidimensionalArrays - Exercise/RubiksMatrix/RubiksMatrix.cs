namespace RubiksMatrix
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split().Select(int.Parse)
                .ToArray();
            int rows = sizes[0];
            int cols = sizes[1];

            int[][] matrix = new int[rows][];
            int num = 1;

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new int[cols];
                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    matrix[row][colIndex] = num;
                    num++;
                }
            }

            int cmdNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < cmdNum; i++)
            {
                string[] commandToken = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int rowOrCol = int.Parse(commandToken[0]);
                string direction = commandToken[1];
                int moves = int.Parse(commandToken[2]);

                switch (direction)
                {
                    case "up":
                        SwapCol(matrix, rowOrCol, moves);
                        break;
                    case "down":
                        SwapCol(matrix, rowOrCol, rows - moves % rows);
                        break;
                    case "left":
                        SwapRow(matrix, rowOrCol, moves);
                        break;
                    case "right":
                        SwapRow(matrix, rowOrCol, cols - moves % cols);
                        break;
                }
            }

            int number = 1;
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    if (matrix[row][col] == number)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
                        {
                            for (int colIndex = 0; colIndex < matrix[0].Length; colIndex++)
                            {
                                if (matrix[rowIndex][colIndex] == number)
                                {
                                    int currentElement = matrix[row][col];
                                    matrix[row][col] = number;
                                    matrix[rowIndex][colIndex] = currentElement;
                                    Console.WriteLine($"Swap ({row}, {col}) with ({rowIndex}, {colIndex})");
                                    break;
                                }
                            }
                        }
                    }

                    number++;
                }
            }
        }

        private static void SwapRow(int[][] matrix, int rowOrcol, int moves)
        {
            int[] temp = new int[matrix[0].Length];
            for (int col = 0; col < matrix[0].Length; col++)
            {
                temp[col] = matrix[rowOrcol][(col + moves) % matrix[0].Length];
            }

            matrix[rowOrcol] = temp;
        }

        private static void SwapCol(int[][] matrix, int rowOrcol, int moves)
        {
            int[] temp = new int[matrix.Length];
            for (int row = 0; row < matrix.Length; row++)
            {
                temp[row] = matrix[(row + moves) % matrix.Length][rowOrcol];
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row][rowOrcol] = temp[row];
            }
        }
    }
}