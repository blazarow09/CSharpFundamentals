using System;
using System.Collections.Generic;

namespace HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            var children = Console.ReadLine().Split();

            var tossLimit = int.Parse(Console.ReadLine());

            var queue = new Queue<string>(children);

            while (queue.Count != 1) 
            {
                for (int tossCounter = 1; tossCounter < tossLimit; tossCounter++)
                {
                    queue.Enqueue(queue.Dequeue());
                }

                Console.WriteLine($"Removed {queue.Dequeue()}");
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
