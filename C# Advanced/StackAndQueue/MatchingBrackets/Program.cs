using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var openBrackets = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    openBrackets.Push(i);
                }
                else if (input[i] == ')')
                {
                    var lenght = i - openBrackets.Peek() + 1; 
                    Console.WriteLine(input.Substring(openBrackets.Pop(), lenght));
                }
            }
        }
    }
}
