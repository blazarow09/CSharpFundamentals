namespace KeyRevolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class KeyRevolver
    {
        static void Main(string[] args)
        {
            var priceBullet = int.Parse(Console.ReadLine());
            var gunBarrel = int.Parse(Console.ReadLine());
            var bullets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var locks = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var intelligence = int.Parse(Console.ReadLine());

            var Bullets = new Stack<int>(bullets);

            var shoots = 0;
            var counter = 0;

            while (true)
            {
                if (OutOfLocks(Bullets, locks, intelligence, shoots, priceBullet))
                {
                    return;
                }

                if (locks[0] >= Bullets.Peek())
                {
                    Console.WriteLine("Bang!");
                    locks.Remove(locks[0]);
                    Bullets.Pop();
                    shoots++;
                }
                else
                {
                    Console.WriteLine("Ping!");
                    Bullets.Pop();
                    shoots++;
                }
                counter++;

                if (counter % gunBarrel == 0 && Bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    counter = 0;
                }
            }
        }

        private static bool OutOfLocks(Stack<int> Bullets, List<int> locks, int intelligence, int shoots, int priceBullet)
        {
            var isTrue = false;
            if (locks.Count == 0)
            {
                var earned = intelligence - (shoots * priceBullet);

                Console.WriteLine($"{Bullets.Count} bullets left. Earned ${earned}");
                isTrue = true;
            }
            else if (Bullets.Count == 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                isTrue = true;
            }
            return isTrue;
        }
    }
}
