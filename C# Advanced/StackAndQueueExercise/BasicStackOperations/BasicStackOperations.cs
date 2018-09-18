
namespace BasicStackOperations
{
    using System;
    using System.Collections.Generic;

    class BasicStackOperations
    {
        static void Main(string[] args)
        {
            var commandArgs = Console.ReadLine().Split();
            var toPush = int.Parse(commandArgs[0]);
            var toPop = int.Parse(commandArgs[1]);
            var toFind = int.Parse(commandArgs[2]);

            var elements = Console.ReadLine().Split();

            var stack = new Stack<int>();
           
            for (int i = 0; i < toPush; i++)
            {
                stack.Push(int.Parse(elements[i]));
            }

            for (int i = 0; i < toPop; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(toFind))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count < 1)
            {
                Console.WriteLine(0);
            }
            else
            {
                //var newStack = stack.ToArray().Min(); - Alternative
                //Console.WriteLine(newStack);

                int[] array = stack.ToArray();
                int max = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] < max)
                    {

                        max = array[i];
                    }
                }
                Console.WriteLine(max);
            }
        }
    }
}
