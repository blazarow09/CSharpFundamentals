using System;
using System.Text;

public class Animal : ISoundProducable
{
    private const string ErrorMessage = "Invalid input!";

    public Animal(string name, int age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    private string name;
    private int age;
    private string gender;

    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ErrorMessage);
            }

            name = value;
        }
    }

    public int Age
    {
        get { return age; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(ErrorMessage);
            }

            age = value;
        }
    }

    public string Gender
    {
        get { return gender; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ErrorMessage);
            }

            if (value != "Male" && value != "Female")
            {
                throw new ArgumentException(ErrorMessage);
            }

            gender = value;
        }
    }

    public object StringBuilder { get; private set; }

    public virtual string ProduceSound()
    {
        return "NOISE";
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder
            .AppendLine($"{this.GetType().Name}")
            .AppendLine($"{this.Name} {this.Age} {this.Gender}").AppendLine(this.ProduceSound());

        return builder.ToString().TrimEnd();
    }
}

