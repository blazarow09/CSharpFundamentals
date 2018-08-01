using System;
using System.Collections.Generic;

namespace CalculateSequenceWithQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = long.Parse(Console.ReadLine());

            var sequence = new Queue<long>();

            Console.Write(N + " ");

            for (int i = 0; i < 17; i++)
            {
                sequence.Enqueue(N + 1);

                sequence.Enqueue(2 * N + 1);

                sequence.Enqueue(N + 2);

                N = sequence.Dequeue();

                Console.Write(N + " ");
            }

            for (int i = 0; i < 32; i++)
            {
                Console.Write(sequence.Dequeue() + " ");
            }
        }
    }
}

