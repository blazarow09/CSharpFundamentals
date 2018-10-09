namespace SoftUniBarIncome
{
    using System;
    using System.Text.RegularExpressions;

    class SoftUniBarIncome
    {
        static void Main(string[] args)
        {
            string pattern = @"%(?<customer>[A-Z]{1}[a-z]+)%[^|$%.]*?<(?<product>\w+?)>[^|$%.]*?\|(?<count>[0-9]+)\|[^|$%.]*?(?<price>[0-9]+?.?[0-9]+?)\$";

            double totalIncome = 0;

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "end of shift")
                {
                    break;
                }

                if (Regex.IsMatch(line, pattern))
                {
                    Match match = Regex.Match(line, pattern);

                    var customer = match.Groups["customer"].Value;
                    var product = match.Groups["product"].Value;
                    var count = int.Parse(match.Groups["count"].Value);
                    var price = double.Parse(match.Groups["price"].Value);

                    var money = price * count;

                    Console.WriteLine($"{customer}: {product} - {money:f2}");

                    totalIncome += money;
                }
            }
            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
