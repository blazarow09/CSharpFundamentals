using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var comands = Console.ReadLine().Split();
            var toPush = Console.ReadLine().Split();
            var countElements = comands[0];
            var toPop = int.Parse(comands[1]);
            var toFind = comands[2];

            var stack = new Queue<string>(toPush);

            for (int i = 0; i < toPop; i++)
            {
                stack.Dequeue();
            }

            if (stack.Contains(toFind))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine($"{stack.ToArray().Min()}");
            }
        }
    }
}
