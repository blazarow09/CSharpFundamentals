using AnimalCentre.Models.Factories;
using AnimalCentre.Models.Hotel;
using AnimalCentre.Models.Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Core
{
    public class AnimalCentre
    {
        private readonly AnimalFactory animalFactory;
        private Hotel hotel;
        private List<Procedure> procedures;
        private Dictionary<string, List<string>> owners;

        public AnimalCentre()
        {
            this.hotel = new Hotel();
            this.procedures = new List<Procedure>();
            this.owners = new Dictionary<string, List<string>>();
            this.animalFactory = new AnimalFactory();
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            if (hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} already exist");
            }
            else
            {
                var animal = this.animalFactory.CreateAnimal(type, name, energy, happiness, procedureTime);

                hotel.Accommodate(animal);
            }

            return $"Animal {name} registered succesfully";
        }

        public string Chip(string name, int procedureTime)
        {
            this.DoesExist(name);

            var animal = hotel.GetAnimal(name);

            if (this.procedures.Any(p => p.GetType().Name == "Chip"))
            {
                this.procedures.First(p => p.GetType().Name == "Chip")
                    .DoService(animal, procedureTime);
            }
            else
            {
                Procedure procedure = new Chip();
                procedure.DoService(animal, procedureTime);
                this.procedures.Add(procedure);
            }

            return $"{name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            this.DoesExist(name);

            var animal = hotel.GetAnimal(name);

            if (this.procedures.Any(p => p.GetType().Name == "Vaccinate"))
            {
                this.procedures.First(p => p.GetType().Name == "Vaccinate")
                    .DoService(animal, procedureTime);
            }
            else
            {
                Procedure procedure = new Vaccinate();
                procedure.DoService(animal, procedureTime);
                this.procedures.Add(procedure);
            }

            return $"{name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            this.DoesExist(name);

            var animal = hotel.GetAnimal(name);

            if (this.procedures.Any(p => p.GetType().Name == "Fitness"))
            {
                this.procedures.First(p => p.GetType().Name == "Fitness")
                    .DoService(animal, procedureTime);
            }
            else
            {
                Procedure procedure = new Fitness();
                procedure.DoService(animal, procedureTime);
                this.procedures.Add(procedure);
            }

            return $"{name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            this.DoesExist(name);

            var animal = hotel.GetAnimal(name);

            if (this.procedures.Any(p => p.GetType().Name == "Play"))
            {
                this.procedures.First(p => p.GetType().Name == "Play")
                    .DoService(animal, procedureTime);
            }
            else
            {
                Procedure procedure = new Play();
                procedure.DoService(animal, procedureTime);
                this.procedures.Add(procedure);
            }

            return $"{name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            this.DoesExist(name);

            var animal = hotel.GetAnimal(name);

            if (this.procedures.Any(p => p.GetType().Name == "DentalCare"))
            {
                this.procedures.First(p => p.GetType().Name == "DentalCare")
                    .DoService(animal, procedureTime);
            }
            else
            {
                Procedure procedure = new DentalCare();
                procedure.DoService(animal, procedureTime);
                this.procedures.Add(procedure);
            }

            return $"{name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            this.DoesExist(name);

            var animal = hotel.GetAnimal(name);

            if (this.procedures.Any(p => p.GetType().Name == "NailTrim"))
            {
                this.procedures.First(p => p.GetType().Name == "NailTrim")
                    .DoService(animal, procedureTime);
            }
            else
            {
                Procedure procedure = new NailTrim();
                procedure.DoService(animal, procedureTime);
                this.procedures.Add(procedure);
            }

            return $"{name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            this.DoesExist(animalName);

            var animal = hotel.GetAnimal(animalName);

            hotel.Adopt(animalName, owner);

            if (this.owners.ContainsKey(owner) == false)
            {
                this.owners.Add(owner, new List<string>());
            }

            this.owners[owner].Add(animal.Name);

            if (animal.IsChipped)
            {
                return $"{owner} adopted animal with chip";
            }
            else
            {
                return $"{owner} adopted animal without chip";
            }
        }

        public string History(string type)
        {
            return this.procedures
                .First(x => x.GetType().Name.ToString() == type)
                .History();
        }

        public string PrintAdoptedAnimals()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var owner in this.owners.OrderBy(o => o.Key))
            {
                sb.AppendLine($"--Owner: {owner.Key}");
                sb.AppendLine($"    - Adopted animals: {string.Join(" ", owner.Value)}");
            }

            return sb.ToString().TrimEnd();
        }

        private void DoesExist(string name)
        {
            if (this.hotel.Animals.ContainsKey(name) == false)
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
        }
    }
}