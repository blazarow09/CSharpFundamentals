namespace ReverseNumber
{
    using System;
    using System.Collections.Generic;

    class ReverseNumber
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
