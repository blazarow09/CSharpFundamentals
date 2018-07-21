using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var comands = Console.ReadLine();
            var toPush = Console.ReadLine().Split();

            var tokens = comands.Split();
            var countToPush = tokens[0];
            var toPop = int.Parse(tokens[1]);
            var toFind = tokens[2];

            var stack = new Stack<string>(toPush);

            for (int i = 0; i < toPop; i++)
            {
                stack.Pop();
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
                var newStack = stack.ToArray().Min();
                Console.WriteLine(newStack);
            }
        
        }
    }
}
