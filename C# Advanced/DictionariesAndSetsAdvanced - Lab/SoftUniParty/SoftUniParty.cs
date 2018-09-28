namespace SoftUniParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SoftUniParty
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine();

            var vipSet = new HashSet<string>();

            var guestSet = new HashSet<string>();

            while (line != "PARTY")
            {
                guestSet.Add(line);

                line = Console.ReadLine();
            }

            line = Console.ReadLine();

            while (line != "END")
            {
                guestSet.Remove(line);

                line = Console.ReadLine();
            }

            foreach (var member in guestSet)
            {
                if (char.IsDigit(member[0]))
                {
                    vipSet.Add(member);
                }
            }

            foreach (var member in guestSet.ToArray())
            {
                if (char.IsDigit(member[0]))
                {
                    guestSet.Remove(member);
                }
            }

            Console.WriteLine(vipSet.Count + guestSet.Count);

            foreach (var vip in vipSet)
            {
                Console.WriteLine($"{vip}");
            }

            foreach (var guest in guestSet)
            {
                Console.WriteLine($"{guest}");
            }
        }
    }
}
