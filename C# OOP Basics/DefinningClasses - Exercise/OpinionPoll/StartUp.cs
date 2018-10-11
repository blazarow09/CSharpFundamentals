using System;
using System.Linq;

namespace OpinionPoll
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var members = new Members();

            var membersCount = int.Parse(Console.ReadLine());

            while (membersCount > 0)
            {
                var personData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var member = new Person(personData[0], int.Parse(personData[1]));

                members.AddMember(member);

                membersCount--;
            }

            foreach (var member in members.People.OrderBy(m => m.Name))
            {
                if (member.Age > 30)
                {
                    Console.WriteLine($"{member.Name} - {member.Age}");
                }
            }
        }
    }
}
