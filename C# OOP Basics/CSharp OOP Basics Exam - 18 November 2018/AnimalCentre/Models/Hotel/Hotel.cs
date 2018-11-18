using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalCentre.Models.Hotel
{
    public class Hotel : IHotel
    {
        private const int capacity = 10;
        private Dictionary<string, IAnimal> animals;

        public Hotel()
        {
            
            this.animals = new Dictionary<string, IAnimal>();
        }

        public IReadOnlyDictionary<string, IAnimal> Animals
        {
            get { return this.animals; }
        }

        public void Accommodate(IAnimal animal)
        {
            if (this.animals.Keys.Count >= capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            if (this.Animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} exist");
            }

            this.animals.Add(animal.Name, animal);
        }

        public void Adopt(string animalName, string owner)
        {
            if (this.Animals.ContainsKey(animalName) == false)
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            var animal = this.animals.Values.Where(n => n.Name == animalName).FirstOrDefault();

            animal.Owner = owner;
            animal.IsAdopt = true;
            this.animals.Remove(animal.Name);
        }

        public IAnimal GetAnimal(string animalName)
        {
            var animal = this.Animals.Values.Where(n => n.Name == animalName).FirstOrDefault();

            return animal;
        }
    }
}