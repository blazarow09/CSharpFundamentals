using System;
using System.Collections.Generic;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var rev = new Stack<char>();

            foreach (var word in input)
            {
                rev.Push(word);
            }

            while (rev.Count > 0)
            {
                Console.Write(rev.Pop());
            }
            Console.WriteLine();
        }

    }
}
