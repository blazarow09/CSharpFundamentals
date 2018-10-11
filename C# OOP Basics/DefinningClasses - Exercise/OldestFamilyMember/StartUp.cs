using System;
using System.Collections.Generic;

class StartUp
{
    static void Main(string[] args)
    {
        var familyBook = new Dictionary<string, Family>();

        var count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            AddMember(count, familyBook);
        }

        GetOldestMember(familyBook);
    }

    private static void GetOldestMember(Dictionary<string, Family> familyBook)
    {
        var oldestMemberAge = 0;
        var oldestMemberName = "";

        foreach (var member in familyBook)
        {
            if (member.Value.Age > oldestMemberAge)
            {
                oldestMemberName = member.Value.Name;
                oldestMemberAge = member.Value.Age;
            }
        }

        Console.WriteLine($"{oldestMemberName} {oldestMemberAge}");
    }

    private static void AddMember(int count, Dictionary<string, Family> familyBook)
    {
        var line = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        var name = line[0];
        var age = int.Parse(line[1]);

        if (familyBook.ContainsKey(name) == false)
        {
            var family = new Family();
            family.Name = name;
            family.Age = age;
            familyBook.Add(name, family);
        }
    }
}
