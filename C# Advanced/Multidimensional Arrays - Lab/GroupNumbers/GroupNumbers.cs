using System;
using System.Linq;

namespace GroupNumbers
{
    class GroupNumbers
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int[][] jaggedArray = new int[3][];
            int[] sizes = new int[3];

            for (int i = 0; i < numbers.Length; i++)
            {
                sizes[Math.Abs(numbers[i] % 3)]++;
            }

            for (int i = 0; i < sizes.Length; i++)
            {
                jaggedArray[i] = new int[sizes[i]];
            }

            int[] indices = new int[3];

            for (int i = 0; i < numbers.Length; i++)
            {
                int remainder = Math.Abs(numbers[i] % 3);

                jaggedArray[remainder][indices[remainder]++] = numbers[i];
            }

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.WriteLine(string.Join(" ", jaggedArray[i]));
            }
        }
    }
}
