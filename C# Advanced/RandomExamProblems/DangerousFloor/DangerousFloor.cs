namespace DangerousFloor
{
    using System;

    class DangerousFloor
    {
        static void Main(string[] args)
        {
            char[,] matrix = new char[8, 8];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] line = Console.ReadLine()
                    .Split(",", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col][0];
                }
            }

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                var piece = command[0];
                var startRow = int.Parse(command[1].ToString());
                var startCol = int.Parse(command[2].ToString());
                var endRow = int.Parse(command[4].ToString());
                var endCol = int.Parse(command[5].ToString());

                if (matrix[startRow, startCol] != piece)
                {
                    Console.WriteLine("There is no such a piece!");
                    continue;
                }

                if (!CanMove(piece, startRow, startCol, endRow, endCol))
                {
                    Console.WriteLine("Invalid move!");
                    continue;
                }

                if (endRow > 7 || endCol > 7)
                {
                    Console.WriteLine("Move go out of board!");
                    continue;
                }

                matrix[startRow, startCol] = 'x';
                matrix[endRow, endCol] = piece;
            }
        }

        private static bool CanMove(char piece, int startRow, int startCol, int endRow, int endCol)
        {
            switch (piece)
            {
                case 'K':
                    return Math.Max(Math.Abs(endRow - startRow), Math.Abs(endCol - startCol)) == 1;
                case 'B':
                    return Math.Abs(endRow - startRow) == Math.Abs(endCol - startCol);
                case 'R':
                    return startRow == endRow || startCol == endCol;
                case 'Q':
                    return Math.Abs(endRow - startRow) == Math.Abs(endCol - startCol) || startRow == endRow || startCol == endCol;
                case 'P':
                    return startCol == endCol && startRow == endRow + 1;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
