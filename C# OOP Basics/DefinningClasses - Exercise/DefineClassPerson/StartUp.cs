using System;

class StartUp
{
    static void Main(string[] args)
    {
        Person person = new Person();

        person.Name = Console.ReadLine();
        person.Age = int.Parse(Console.ReadLine());

        Console.WriteLine(person.ToString());
    }
}
