namespace BalancedParentheses
{
    using System;
    using System.Linq;

    class BalancedParentheses
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine()
                .Split()
                .ToArray();

            bool isBalanced = false;

            for (int i = 0; i < line[0].Length / 2; i++)
            {
                char rightSide = line[0][i];
                char leftSide = line[0][line[0].Length - i - 1];

                if (rightSide.Equals('{') && leftSide.Equals('}'))
                {
                    isBalanced = true;
                }
                else if (rightSide.Equals('(') && leftSide.Equals(')'))
                {
                    isBalanced = true;
                }
                else if (rightSide.Equals('[') && leftSide.Equals(']'))
                {
                    isBalanced = true;
                }
                else
                {
                    isBalanced = false;
                }
            }

            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
           
        }
    }
}
