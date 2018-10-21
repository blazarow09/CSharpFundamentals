using System;

namespace Mankind
{
    internal class StartUp
    {
        private static void Main(string[] args)
        {
            var studentTokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var workerTokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            try
            {
                var student = new Student(studentTokens[0],
                                studentTokens[1],
                                studentTokens[2]);
                var worker = new Worker(workerTokens[0],
                                workerTokens[1],
                                double.Parse(workerTokens[2]),
                                double.Parse(workerTokens[3]));

                Console.WriteLine(student);
                Console.WriteLine();
                Console.WriteLine(worker);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}