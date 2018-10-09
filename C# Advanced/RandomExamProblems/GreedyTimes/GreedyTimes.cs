namespace GreedyTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class GreedyTimes
    {
        static void Main(string[] args)
        {
            var amountOfBag = double.Parse(Console.ReadLine());
            var sequenceOfItems = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var goldBag = new Dictionary<string, int>();
            var gemBag = new Dictionary<string, int>();
            var cashBag = new Dictionary<string, int>();

            goldBag["Gold"] = 0;

            AddValues(goldBag, gemBag, cashBag, sequenceOfItems);
            
            
        }

        private static void AddValues(Dictionary<string, int> goldBag, Dictionary<string, int> gemBag, Dictionary<string, int> cashBag, string[] sequenceOfItems)
        {
            for (int i = 0; i < sequenceOfItems.Length; i+= 2)
            {
                var currency = sequenceOfItems[i];
                var value = int.Parse(sequenceOfItems[i + 1]);

                if (currency == "Gold")
                {
                    goldBag["Gold"] += value;
                }
            }
        }
    }
}