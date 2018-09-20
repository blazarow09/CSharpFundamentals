namespace _2x2SquaresMatrix
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string[,] matrix = new string[size[0], size[1]];

            for (int rows = 0; rows < size[0]; rows++)
            {
                var rowsValue = Console.ReadLine()
                    .Split();
                    

                for (int cols = 0; cols < size[1]; cols++)
                {
                    matrix[rows, cols] = rowsValue[cols];
                }
            }

            var isEqual = 0;

            for (int rows = 0; rows < matrix.GetLength(0) -1; rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1) -1; cols++)
                {
                    if (matrix[rows,cols] == matrix[rows, cols + 1] &&
                        matrix[rows + 1, cols] == matrix[rows, cols + 1] &&
                        matrix[rows, cols] == matrix[rows + 1, cols ] &&
                        matrix[rows, cols] == matrix[rows + 1, cols + 1])
                    {
                        isEqual++;
                    }
                }
            }

            Console.WriteLine(isEqual);
        }
    }
}
