using System;

public class Person
{
    private string name;

    public string Name
    {
        get { return name; }
    }

    private int age;

    public int Age
    {
        get { return age; }
    }

    public Person() : this("No name", 1)
    {

    }

    public Person(int age) : this("No name", age)
    {

    }

    public Person(string name, int age)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new NullReferenceException("Invalid name");

        }

        this.name = name;
        this.age = age;
    }
}
