namespace _03.Wild_Farm
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string inputLine;
            while ((inputLine = Console.ReadLine()) != "End")
            {
               
                    var animalInfo = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var animalType = animalInfo[0];
                    var animalName = animalInfo[1];
                    var animalWeight = double.Parse(animalInfo[2]);
                    var animalRegion = animalInfo[3];

                    var foodInfo = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                    Food food;
                    if (foodInfo[0] == "Vegetable")
                        food = new Vegetable(int.Parse(foodInfo[1]));
                    else 
                        food = new Meat(int.Parse(foodInfo[1]));

                    Animal animal;
                    switch (animalType)
                    {
                        case "Mouse":
                            animal = new Mouse(animalName, animalType, animalWeight, animalRegion);
                            break;
                        case "Zebra":
                            animal = new Zebra(animalName, animalType, animalWeight, animalRegion);
                            break;
                        case "Cat":
                            animal = new Cat(animalName, animalType, animalWeight, animalRegion, animalInfo[4]);
                            break;
                        case "Tiger":
                            animal = new Tiger(animalName, animalType, animalWeight, animalRegion);
                            break;
                        default:
                            animal = null;
                            break;
                    }

                    Console.WriteLine(animal.MakeSound());

                    try
                    {
                        animal.Eat(food);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    
                    Console.WriteLine(animal);
               
            }
        }

        public static void GetDog(Cat jj)
        {
            
        }
    }
}
