using System;
using System.Linq;

namespace LegoBlocks
{
    class LegoBlocks
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[][] firstJaggedArray = new int[size][];

            int[][] secondJaggedArray = new int[size][];

            for (int row = 0; row < firstJaggedArray.Length; row++)
            {
                var inputNumbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                firstJaggedArray[row] = new int[inputNumbers.Length];

                for (int col = 0; col < firstJaggedArray[row].Length - 1; col++)
                {
                    firstJaggedArray[row][col] = inputNumbers[col];
                }
            }

            for (int row = 0; row < secondJaggedArray.Length; row++)
            {
                var inputNumbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .Reverse()
                    .ToArray();

                secondJaggedArray[row] = new int[inputNumbers.Length];

                for (int col = 0; col < secondJaggedArray[row].Length; col++)
                {
                    secondJaggedArray[row][col] = inputNumbers[col];
                }
            }
        }
    }
}
