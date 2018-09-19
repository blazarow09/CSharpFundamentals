namespace SimpleTextEditor
{
    using System;
    using System.Collections.Generic;

    class SimpleTextEditor
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());

            var text = new Stack<string>();
            text.Push("");

            for (int i = 0; i < N; i++)
            {
                var cmdArgs = Console.ReadLine().Split();

                switch (int.Parse(cmdArgs[0]))
                {
                    case 1:
                        string newText = text.Peek() + cmdArgs[1];
                        text.Push(newText);
                        break;
                    case 2:
                        string previuos = text.Peek();
                        int charsToCut = int.Parse(cmdArgs[1]);
                        string substring = previuos.Substring(0, previuos.Length - charsToCut);
                        text.Push(substring);
                        break;
                    case 3:
                        string current = text.Peek();
                        int index = int.Parse(cmdArgs[1]);
                        Console.WriteLine(current[index - 1]);
                        break;
                    case 4:
                        text.Pop();
                        break;
                }
            }
        }
    }
}
