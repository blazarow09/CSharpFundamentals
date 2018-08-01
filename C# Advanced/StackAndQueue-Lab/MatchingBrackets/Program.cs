using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var openBracketsIndexes = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    openBracketsIndexes.Push(i);
                }
                if (input[i] == ')')
                {
                    var openBracketIndex = openBracketsIndexes.Pop();
                    var length = i - openBracketIndex + 1;
                    Console.WriteLine(input.Substring(openBracketIndex, length));
                }
            }
        }
    }
}
