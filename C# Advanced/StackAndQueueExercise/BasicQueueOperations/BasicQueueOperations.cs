namespace BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class BasicQueueOperations
    {
        static void Main(string[] args)
        {
            var cmdArgs = Console.ReadLine().Split();
            var inputQueue = Console.ReadLine().Split().Select(int.Parse);

            var queue = new Queue<int>(inputQueue);

            var toDequeue = int.Parse(cmdArgs[1]);
            var toFind = int.Parse(cmdArgs[2]);

            for (int i = 0; i < toDequeue; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count < 1)
            {
                Console.WriteLine(0);
                return;
            }

            var arr = queue.ToArray().Contains(toFind);

            if (arr == true)
            {
                Console.WriteLine("true");
            }
            else
            {
                var min = queue.ToArray().Min();

                Console.WriteLine(min);
            }
        }
    }
}
