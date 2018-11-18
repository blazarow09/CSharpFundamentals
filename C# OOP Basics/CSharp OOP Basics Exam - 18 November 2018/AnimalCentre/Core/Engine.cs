using AnimalCentre.Models.Hotel;
using System;
using System.Linq;

namespace AnimalCentre.Core
{
    public class Engine
    {
        private static string command;

        public void Run()
        {
            Hotel hotel = new Hotel();
            AnimalCentre animalCentre = new AnimalCentre();

            var line = Console.ReadLine()
                .Split()
                .ToList();

            var isRunning = true;
            command = line[0];

            while (isRunning)
            {
                string name = string.Empty;
                command = line[0];

                switch (command)
                {
                    case "RegisterAnimal":
                        var type = line[1];
                        name = line[2];
                        var energy = int.Parse(line[3]);
                        var happiness = int.Parse(line[4]);
                        var procedureTime = int.Parse(line[5]);

                        try
                        {
                            Console.WriteLine(animalCentre.RegisterAnimal(type, name, energy, happiness, procedureTime));
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine("ArgumentException: " + ex.Message);
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine("InvalidOperationException: " + ex.Message);
                        }
                        break;

                    case "Chip":
                        name = line[1];
                        procedureTime = int.Parse(line[2]);

                        try
                        {
                            Console.WriteLine(animalCentre.Chip(name, procedureTime));
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine("ArgumentException: " + ex.Message);
                        }
                        break;

                    case "Vaccinate":
                        name = line[1];
                        procedureTime = int.Parse(line[2]);

                        try
                        {
                            Console.WriteLine(animalCentre.Vaccinate(name, procedureTime));
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine("ArgumentException: " + ex.Message);
                        }
                        break;

                    case "Fitness":
                        name = line[1];
                        procedureTime = int.Parse(line[2]);

                        try
                        {
                            Console.WriteLine(animalCentre.Fitness(name, procedureTime));
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine("ArgumentException: " + ex.Message);
                        }
                        break;

                    case "Play":
                        name = line[1];
                        procedureTime = int.Parse(line[2]);

                        try
                        {
                            Console.WriteLine(animalCentre.Play(name, procedureTime));
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine("ArgumentException: " + ex.Message);
                        }
                        break;

                    case "DentalCare":
                        name = line[1];
                        procedureTime = int.Parse(line[2]);

                        try
                        {
                            Console.WriteLine(animalCentre.DentalCare(name, procedureTime));
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine("ArgumentException: " + ex.Message);
                        }
                        break;

                    case "NailTrim":
                        name = line[1];
                        procedureTime = int.Parse(line[2]);

                        try
                        {
                            Console.WriteLine(animalCentre.NailTrim(name, procedureTime));
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine("ArgumentException: " + ex.Message);
                        }
                        break;

                    case "Adopt":
                        name = line[1];
                        var owner = line[2];

                        try
                        {
                            Console.WriteLine(animalCentre.Adopt(name, owner));
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine("ArgumentException: " + ex.Message);
                        }
                        break;

                    case "History":
                        var procedureType = line[1];

                        try
                        {
                            Console.WriteLine(animalCentre.History(procedureType));
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine("ArgumentException: " + ex.Message);
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine("InvalidOperationException: " + ex.Message);
                        }
                        break;
                }

                line = Console.ReadLine()
                .Split()
                .ToList();

                if (line[0] == "End")
                {
                    isRunning = false;
                }
            }

            Console.WriteLine(animalCentre.PrintAdoptedAnimals());
        }
    }
}