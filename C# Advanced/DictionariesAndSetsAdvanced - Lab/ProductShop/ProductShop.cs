namespace ProductShop
{
    using System;
    using System.Collections.Generic;

    class ProductShop
    {
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine()
               .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            var dictionary = new SortedDictionary<string, Dictionary<string, double>>();

            while (tokens[0] != "Revision")
            {
                var shop = tokens[0];
                var product = tokens[1];
                var price = double.Parse(tokens[2]);

                if (dictionary.ContainsKey(shop) == false)
                {
                    dictionary[shop] = new Dictionary<string, double>
                    {
                        { product, price }
                    };
                }
                else if (dictionary.ContainsKey(shop))
                {
                    dictionary[shop].Add(product, price);
                }

                tokens = Console.ReadLine()
               .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key}->");

                foreach (var product in item.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
