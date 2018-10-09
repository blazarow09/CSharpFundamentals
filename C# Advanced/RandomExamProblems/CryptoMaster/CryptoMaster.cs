namespace CryptoMaster
{
    using System;
    using System.Linq;

    class CryptoMaster
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(new[] { ", " } ,
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var longestRun = 1;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 1; j < array.Length; j++)
                {
                    int currentIndex = i;

                    int nextIndex = (currentIndex + j) % array.Length;
                    int currentRun = 1;

                    while (array[nextIndex] > array[currentIndex])
                    {
                        currentRun++;

                        if (currentRun > longestRun)
                        {
                            longestRun = currentRun;
                        }

                        currentIndex = nextIndex;
                        nextIndex = (currentIndex + j) % array.Length;
                    }
                }
            }

            Console.WriteLine(longestRun);
        }
    }
}
