namespace RecordUniqueNames
{
    using System;
    using System.Collections.Generic;

    class RecordUniqueNames
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());

            var book = new HashSet<String>();

            for (int i = 0; i < count; i++)
            {
                var line = Console.ReadLine();

                book.Add(line);
            }

            Console.WriteLine(String.Join(Environment.NewLine, book));
        }
    }
}
