using System;

namespace PascalTriangle
{
    class PascalTriangle
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            long[][] jaggedArray = new long[height][];

            for (int i = 1; i <= height; i++)
            {
                jaggedArray[i - 1] = new long[i];
                jaggedArray[i - 1][0] = 1;
                jaggedArray[i - 1][jaggedArray[i - 1].Length - 1] = 1;
             }

            for (int i = 2; i < height; i++)
            {
                for (int j = 1; j < jaggedArray[i].Length - 1; j++)
                {
                    jaggedArray[i][j] = jaggedArray[i - 1][j - 1] + jaggedArray[i - 1][j];
                }
            }

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.WriteLine(string.Join(" ", jaggedArray[i]));
            }
        }
    }
}
