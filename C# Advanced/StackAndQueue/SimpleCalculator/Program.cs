using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();

            var stack = new Stack<string>(input.Reverse());

            while (stack.Count != 1)
            {
                var leftOperand = int.Parse(stack.Pop());
                var operand = stack.Pop();
                var rightOperand = int.Parse(stack.Pop());

                switch (operand)
                {
                    case "+":
                        stack.Push((leftOperand + rightOperand).ToString());
                        break;
                    case "-":
                        stack.Push((leftOperand - rightOperand).ToString());
                        break;
                }
            }
            Console.WriteLine(stack.Peek());
        }
    }
}
