using System;
using System.Collections.Generic;

namespace ReverseNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var stack = new Stack<string>(input.Split());

            foreach (var item in stack)
            {
                Console.Write(item.ToString() + " ");
            }
            

        }
    }
}
