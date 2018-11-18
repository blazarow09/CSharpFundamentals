using AnimalCentre.Models.Animals;

namespace AnimalCentre.Models.Factories
{
    public class AnimalFactory
    {
        public Animal CreateAnimal(string type, string name, int energy, int happiness, int playTime)
        {
            switch (type)
            {
                case "Cat":
                    return new Cat(name, energy, happiness, playTime);

                case "Dog":
                    return new Dog(name, energy, happiness, playTime);

                case "Lion":
                    return new Lion(name, energy, happiness, playTime);

                case "Pig":
                    return new Pig(name, energy, happiness, playTime);

                default:
                    return null;
            }
        }
    }
}