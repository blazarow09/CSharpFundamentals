using System;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        Type personType = typeof(Person);
        ConstructorInfo emptyCtor = personType.GetConstructor(new Type[] { });
        ConstructorInfo ageCtor = personType.GetConstructor(new[] { typeof(int) });
        ConstructorInfo nameAgeCtor = personType.GetConstructor(new[] { typeof(string), typeof(int) });

        bool isSwapped = false;

        if (nameAgeCtor == null)
        {
            nameAgeCtor = personType.GetConstructor(new[] { typeof(int), typeof(string) });

            isSwapped = true;
        }

        var name = Console.ReadLine();
        var age = int.Parse(Console.ReadLine());

        Person basePerson = (Person)emptyCtor.Invoke(new object[] { });
        Person personWithAge = (Person)ageCtor.Invoke(new object[] { age });
        Person personWithAgeAndName = isSwapped ? (Person)nameAgeCtor.Invoke(new object[] { age, name }) : (Person)nameAgeCtor.Invoke(new object[] { name, age });

        Console.WriteLine($"{basePerson.Name} {basePerson.Age}");
        Console.WriteLine($"{personWithAge.Name} {personWithAge.Age}");
        Console.WriteLine($"{personWithAgeAndName.Name} {personWithAgeAndName.Age}");
    }
}
