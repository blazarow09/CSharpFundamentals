using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseStringWithAStack
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();

            var stack = new Stack<string>(input);

            Console.WriteLine(string.Join(" ", stack));
        }
    }
}
