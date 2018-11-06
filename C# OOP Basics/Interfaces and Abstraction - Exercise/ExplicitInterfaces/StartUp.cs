using System;

namespace PersonInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var line = Console.ReadLine();

            while (line != "End")
            {
                var tokens = line.Split();

                IResident citizen = new Citizen(tokens[0]);
                IPerson mrsCitizen = new Citizen(tokens[0]);

                Console.WriteLine(mrsCitizen.GetName());
                Console.WriteLine(citizen.GetName());

                line = Console.ReadLine();
            }
        }
    }
}