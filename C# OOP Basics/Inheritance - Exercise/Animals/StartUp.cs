using Animals.Animal;
using System;

namespace Animals
{
    internal class StartUp
    {
        private static void Main(string[] args)
        {
            string animalSpecies, name, age, gender = "n/a";
            string[] animalInfo;

            while (true)
            {
                animalSpecies = Console.ReadLine();

                if (animalSpecies == "Beast!")
                {
                    break;
                }

                animalInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                name = animalInfo[0];
                age = animalInfo[1];

                if (animalInfo.Length == 3)
                {
                    gender = animalInfo[2];
                }

                switch (animalSpecies)
                {
                    case "Dog":
                        try
                        {
                            var dog = new Dog(name, age, gender);
                            Console.WriteLine(dog);
                            Console.WriteLine(dog.ProduceSound());
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "Cat":
                        try
                        {
                            var cat = new Cat(name, age, gender);
                            Console.WriteLine(cat);
                            Console.WriteLine(cat.ProduceSound());
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "Frog":
                        try
                        {
                            var frog = new Frog(name, age, gender);
                            Console.WriteLine(frog);
                            Console.WriteLine(frog.ProduceSound());
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "Kitten":
                        try
                        {
                            var kitten = new Kitten(name, age, gender);
                            Console.WriteLine(kitten);
                            Console.WriteLine(kitten.ProduceSound());
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "Tomcat":
                        try
                        {
                            var tomcat = new Tomcat(name, age, gender);
                            Console.WriteLine(tomcat);
                            Console.WriteLine(tomcat.ProduceSound());
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                }
            }
        }
    }
}