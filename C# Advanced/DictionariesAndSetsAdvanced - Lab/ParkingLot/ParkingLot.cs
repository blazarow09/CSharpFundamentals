namespace ParkingLot
{
    using System;
    using System.Collections.Generic;

    class ParkingLot
    {
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            
            var set = new HashSet<string>();

            while (tokens[0] != "END")
            {
                var direction = tokens[0];
                var carNumber = tokens[1];

                if (direction == "IN")
                {
                    set.Add(carNumber);
                }
                else if (direction == "OUT")
                {
                    set.Remove(carNumber);
                }

                tokens = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }

            if (set.Count < 1)
            {
                Console.WriteLine("Parking Lot is Empty");
                return;
            }

            foreach (var carNumber in set)
            {
                Console.WriteLine(carNumber);
            }
        }
    }
}
