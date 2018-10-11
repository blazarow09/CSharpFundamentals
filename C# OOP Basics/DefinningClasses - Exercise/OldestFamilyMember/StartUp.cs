using System;
//using System.Reflection;

class StartUp
{
    static void Main(string[] args)
    {

        //MethodInfo oldestMember = typeof(Family).GetMethod("GetOldestMember");
        //MethodInfo addMember = typeof(Family).GetMethod("AddMember");

        //***Checks whether the input is not null***//

        //if (oldestMember == null || addMember == null)
        //{
        //    throw new Exception();
        //}

        var family = new Family();

        var membersCount = int.Parse(Console.ReadLine());

        while (membersCount > 0) 
        {
            var personData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var member = new Person(personData[0], int.Parse(personData[1]));

            family.AddMember(member);

            membersCount--;
        }

        var oldestMemberPrint = family.GetOldestMember();

        Console.WriteLine($"{oldestMemberPrint.Name} {oldestMemberPrint.Age}");
    }
}
