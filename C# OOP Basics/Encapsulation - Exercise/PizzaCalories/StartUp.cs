namespace PizzaCalories
{
    using System;

    internal class StartUp
    {
        private static string pizzaName;
        private static double doughCalories;
        private static double toppingCalories;

        private static void Main(string[] args)
        {
            var pizzaTokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (pizzaTokens.Length > 1)
            {
                pizzaName = pizzaTokens[1];
            }

            var inputTokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Pizza pizza = new Pizza();

            try
            {
                while (inputTokens[0] != "END")
                {
                    if (inputTokens[0] == "Dough")
                    {
                        var dough = new Dough(inputTokens[1],
                            inputTokens[2],
                            int.Parse(inputTokens[3]));

                        doughCalories = dough.Calories();

                        pizza = new Pizza(pizzaName, dough);
                    }
                    else if (inputTokens[0] == "Topping")
                    {
                        var topping = new Topping(inputTokens[1],
                            int.Parse(inputTokens[2]));

                        toppingCalories += topping.Calories();

                        pizza.AddTopping(topping);
                    }

                    inputTokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }

            var totalCalories = doughCalories + toppingCalories;

            Console.WriteLine($"{pizzaName} - {totalCalories:f2} Calories.");
        }
    }
}