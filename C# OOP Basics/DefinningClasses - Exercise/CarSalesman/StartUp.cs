using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int linesOfEngines = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();

            for (int engine = 0; engine < linesOfEngines; engine++)
            {
                string[] tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = tokens[0];
                int power = int.Parse(tokens[1]);


                if (tokens.Length == 2)
                {
                    Engine engineInfo = new Engine(model, power);
                    engines.Add(engineInfo);
                }
                else if (tokens.Length == 3)
                {
                    if (tokens[2].All(Char.IsDigit))
                    {
                        int displacement = int.Parse(tokens[2]);
                        Engine engineInfo = new Engine(model, power, displacement);
                        engines.Add(engineInfo);
                    }
                    else
                    {
                        string efficiency = tokens[2];
                        Engine engineInfo = new Engine(model, power, efficiency);
                        engines.Add(engineInfo);
                    }
                }
                else if (tokens.Length == 4)
                {
                    int displacement = int.Parse(tokens[2]);
                    string efficiency = tokens[3];
                    Engine engineInfo = new Engine(model, power, displacement, efficiency);
                    engines.Add(engineInfo);
                }
            }

            int linesOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int car = 0; car < linesOfCars; car++)
            {
                string[] tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = tokens[0];
                string engineModel = tokens[1];

                Engine engine = engines.First(e => e.Model == engineModel);

                if (tokens.Length == 2)
                {
                    Car carInfo = new Car(model, engine);
                    cars.Add(carInfo);
                }
                else if (tokens.Length == 3)
                {
                    if (tokens[2].All(Char.IsDigit))
                    {
                        int weight = int.Parse(tokens[2]);
                        Car carInfo = new Car(model, engine, weight);
                        cars.Add(carInfo);
                    }
                    else
                    {
                        string color = tokens[2];
                        Car carInfo = new Car(model, engine, color);
                        cars.Add(carInfo);
                    }
                }
                else if (tokens.Length == 4)
                {
                    int weight = int.Parse(tokens[2]);
                    string color = tokens[3];
                    Car carInfo = new Car(model, engine, weight, color);
                    cars.Add(carInfo);
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
