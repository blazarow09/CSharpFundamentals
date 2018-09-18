namespace MaximumElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MaximumElement
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();

            for (int i = 0; i < lines; i++)
            {
                var inputArgs = Console.ReadLine().Split(" ");
                var cmd = inputArgs[0];

                if (cmd == "1")
                {
                    var val = inputArgs[1];

                    stack.Push(int.Parse(val));
                }
                else if (cmd == "2")
                {
                    stack.Pop();
                }
                else if (cmd == "3")
                {
                    var maxNum = stack.ToArray().Max();

                    Console.WriteLine(maxNum);
                }
            }

        }
    }
}
