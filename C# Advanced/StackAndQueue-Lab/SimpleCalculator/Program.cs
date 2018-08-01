using System;
using System.Collections.Generic;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();

            var stack = new Stack<string>();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                stack.Push(input[i]);
            }

            var result = 0;

            while (stack.Count != 1)
            {
                var leftOperand = int.Parse(stack.Pop());
                var symbol = stack.Pop();
                var rightOperand = int.Parse(stack.Pop());

                switch (symbol)
                {
                    case "+":
                         result = leftOperand + rightOperand;
                        stack.Push(result.ToString());
                        break;
                    case "-":
                         result = leftOperand - rightOperand;
                        stack.Push(result.ToString());
                        break;
                }
            }

            Console.WriteLine(stack.Peek());
        }
    }
}
