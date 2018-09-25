namespace MatrixOfPalindromes
{
    using System;
    using System.Linq;

    class MatrixOfPalindromes
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            var rows = sizes[0];
            var cols = sizes[1];

            char[,] matrix = new char[rows, cols];

            char a = 'a';
            char b = 'a';

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(a);
                    Console.Write(b);
                    Console.Write(a + " ");
                    b++;
                }
                Console.WriteLine();
                a++;
                b = a;
            }
        }
    }
}
