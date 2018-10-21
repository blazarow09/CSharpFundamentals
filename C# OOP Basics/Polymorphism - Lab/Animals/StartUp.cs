using Animals.Exceptions;
using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var listOfAnimals = new List<Animal>();

            var animalType = Console.ReadLine();
            var animalTokens = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            while (true)
            {
                var name = animalTokens[0];
                var food = animalTokens[1];
                string gender;
                

                switch (animalType)
                {
                    case "Dog":
                        try
                        {
                           
                            if (animalTokens.Length > 2)
                            {
                                gender = animalTokens[2];
                                Dog dog = new Dog(name, food, gender);

                                Console.WriteLine(dog.ExplainMyselft());
                            }
                            else
                            {
                                Animal dog = new Dog(name, food);

                                Console.WriteLine(dog.ExplainMyselft());
                            }

                            Console.WriteLine("Animal added.");
                        }
                        catch (InvalidInputException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "Cat":
                        try
                        {
                            Animal cat = new Cat(name, food);

                            Console.WriteLine(cat.ExplainMyselft());
                            Console.WriteLine("Animal added.");
                        }
                        catch (InvalidInputException ex)
                        {

                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "Fish":
                        try
                        {
                            Animal fish = new Fish(name, food);

                            Console.WriteLine(fish.ExplainMyselft());
                            Console.WriteLine("Animal added.");
                        }
                        catch (InvalidInputException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                }

                animalType = Console.ReadLine();

                if (animalType == "End")
                {
                    break;
                }

                animalTokens = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);
            }

            
        }
    }
}