namespace Crossroads
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Crossroads
    {
        static void Main(string[] args)
        {
            var greenLight = int.Parse(Console.ReadLine());
            var freeWindow = int.Parse(Console.ReadLine());

            var queue = new Queue<string>();
            var totalCarsPassed = 0;

            string tokens;

            while ((tokens = Console.ReadLine()) != "END")
            {

                if (tokens != "green")
                {
                    queue.Enqueue(tokens);
                    continue;
                }

                int currGreenLight = greenLight;

                string passingCar = null;

                while (currGreenLight > 0 && queue.Any())
                {
                    passingCar = queue.Dequeue();
                    currGreenLight -= passingCar.Length;
                    totalCarsPassed++;
                }

                int freeWindowLeft = freeWindow + currGreenLight;

                if (freeWindowLeft < 0)
                {
                    var symbolsThatDidntPass = Math.Abs(freeWindowLeft);
                    var indexOfHitSymbol = passingCar.Length - symbolsThatDidntPass;
                    char symbolHit = passingCar[indexOfHitSymbol];

                    Console.WriteLine($"A crash happened!");
                    Console.WriteLine($"{passingCar} was hit at {symbolHit}.");
                    Environment.Exit(0);
                }
            }
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
        }
    }
}
