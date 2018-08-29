using System;
using System.Collections.Generic;

namespace DecimalToBinaryConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputInDecimal = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();

            if (inputInDecimal == 0)
            {
                Console.WriteLine(0);
                return;
            }

            while (inputInDecimal > 0)
            {
                stack.Push(inputInDecimal % 2);
                inputInDecimal /= 2;
            }

            while (stack.Count > 0)
            {
            Console.Write(stack.Pop());
            }

        }
    }
}
