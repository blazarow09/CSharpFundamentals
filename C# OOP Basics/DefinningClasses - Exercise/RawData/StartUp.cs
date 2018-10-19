namespace RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());

            var cars = new List<Car>();

            for (int i = 0; i < count; i++)
            {
                var tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var model = tokens[0];
                var speed = int.Parse(tokens[1]);
                var power = int.Parse(tokens[2]);
                var weight = int.Parse(tokens[3]);
                var type = tokens[4];

                var tires = new List<Tires>();

                for (int j = 5; j < tokens.Length; j += 2)
                {
                    var pressure = double.Parse(tokens[j]);
                    var age = int.Parse(tokens[j + 1]);

                    Tires tireInfo = new Tires(pressure, age);
                    tires.Add(tireInfo);
                }

                Engine engine = new Engine(speed, power);
                Cargo cargo = new Cargo(type, weight);
                Car carInfo = new Car(model, engine, cargo, tires);

                cars.Add(carInfo);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                cars.Where(c => c.cargo.Type == "fragile").Where(c => c.tires.Any(t => t.pressure < 1)).Select(c => c.model).ToList().ForEach(m => Console.WriteLine(m));
            }
            else if (command == "flamable")
            {
                cars.Where(c => c.cargo.Type == "flamable").Where(c => c.engine.EnginePower > 250).Select(c => c.model).ToList().ForEach(m => Console.WriteLine(m));
            }
        }
    }
}