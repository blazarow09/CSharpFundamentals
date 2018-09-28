namespace UniqueUsernames
{
    using System;
    using System.Collections.Generic;

    class UniqueUsernames
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            var usernames = new HashSet<string>();

            for (int i = 0; i < count; i++)
            {
                var username = Console.ReadLine();

                usernames.Add(username);
            }

            foreach (var username in usernames)
            {
                Console.WriteLine($"{username}");
            }
        }
    }
}
