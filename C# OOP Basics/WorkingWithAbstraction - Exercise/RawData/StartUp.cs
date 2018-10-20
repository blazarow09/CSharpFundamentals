namespace P01_RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RawData
    {
        private static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = parameters[0];
                int engineSpeed = int.Parse(parameters[1]);
                int enginePower = int.Parse(parameters[2]);
                int cargoWeight = int.Parse(parameters[3]);
                string cargoType = parameters[4];

                var engine = new Engine(enginePower, engineSpeed);
                var cargo = new Cargo(cargoType, cargoWeight);
                var tires = new List<Tires>();

                for (int j = 5; j < parameters.Length; j += 2)
                {
                    var pressure = double.Parse(parameters[j]);
                    var age = int.Parse(parameters[j + 1]);

                    var tire = new Tires(age, pressure);

                    tires.Add(tire);
                }

                var car = new Car(model, engine, cargo, tires);

                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.Cargo.CargoType == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = cars
                    .Where(x => x.Cargo.CargoType == "flamable" && x.Engine.Power > 250)
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }
    }
}