namespace CalculateSequenceWithQueue
{
    using System;
    using System.Collections.Generic;

    class CalculateSequenceWithQueue
    {
        static void Main(string[] args)
        {
            var number = long.Parse(Console.ReadLine());

            var queue = new Queue<long>();
            var counter = 0;

            queue.Enqueue(number);

            while (counter < 50)
            {
                var currentNumber = queue.Peek();

                queue.Enqueue(currentNumber + 1);
                queue.Enqueue(2 * currentNumber + 1);
                queue.Enqueue(currentNumber + 2);

                Console.Write(queue.Dequeue() + " ");

                counter++;
            }
        }
    }
}
