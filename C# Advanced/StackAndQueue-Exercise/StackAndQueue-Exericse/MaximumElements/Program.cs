using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();
            var element = 0;
            var command = "";

            while (n != 0)
            {
                var input = Console.ReadLine();
                var tokens = input.Split();

                command = tokens[0];

                if (command == "1")
                {
                    element = int.Parse(tokens[1]);
                    stack.Push(element);
                }
                else if (command == "2")
                {
                    stack.Pop();
                }
                else
                {
                    var min = stack.ToArray().Max();
                    Console.WriteLine($"{min}");
                }
                n--;
            }
        }
    }
}
