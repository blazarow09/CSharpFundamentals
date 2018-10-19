namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main(string[] args)
        {
            var personsTokens = Console.ReadLine()
                 .Split(";", StringSplitOptions.RemoveEmptyEntries);
            var productTokens = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            var persons = new List<Person>();
            var products = new List<Product>();

            try
            {
                AddPersons(personsTokens, persons);

                AddProducts(productTokens, products);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }

            var clientArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (clientArgs[0] != "END")
            {
                var personName = clientArgs[0];
                var productName = clientArgs[1];

                var person = persons.Where(p => p.Name == personName).First();
                var product = products.Where(p => p.ProductName == productName).First();

                if (person.Money >= product.Price)
                {
                    person.DecreaseMoney(product.Price);
                    person.AddProductInBag(product);
                    Console.WriteLine($"{person.Name} bought {product.ProductName}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} can't afford {product.ProductName}");
                }

                clientArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            PrintBag(persons);
        }

        private static void PrintBag(List<Person> persons)
        {
            foreach (var person in persons)
            {
                if (person.SeeBag().Count > 0)
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.SeeBag().Select(p => p.ProductName))}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }

        private static void AddProducts(string[] productTokens, List<Product> products)
        {
            foreach (var p in productTokens)
            {
                var nameAndPrice = p
                    .Split("=")
                    .ToList();

                var product = new Product(nameAndPrice[0], double.Parse(nameAndPrice[1]));

                products.Add(product);
            }
        }

        private static void AddPersons(string[] personsTokens, List<Person> persons)
        {
            foreach (var p in personsTokens)
            {
                var nameAndMoney = p
                    .Split("=")
                    .ToList();

                var person = new Person(nameAndMoney[0], double.Parse(nameAndMoney[1]));

                persons.Add(person);
            }
        }
    }
}