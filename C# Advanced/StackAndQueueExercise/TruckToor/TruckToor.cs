namespace TruckToor
{
    using System;
    using System.Linq;

    class TruckToor
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            int smallestIndex = 0;
            int fuel = 0;

            for (int index = 0; index < N; index++)
            {
                var input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var amountOfPetrol = input[0];
                var distance = input[1];

                fuel += amountOfPetrol - distance;

                if (fuel < 0)
                {
                    fuel = 0;
                    smallestIndex = index + 1;
                }
            }
            Console.WriteLine(smallestIndex);
        }
    }
}
