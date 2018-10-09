namespace TicketTrouble
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class TicketTrouble
    {
        static void Main(string[] args)
        {
            var destination = Console.ReadLine();

            var suitcase = Console.ReadLine();

            string firPattern = @"{.*\[(" + destination + @")\].*\[([A-Z]{1}[0-9]{1,2})\].*}";
            string secPattern = @"\[.*{(" + destination + @")}.*{([A-Z]{1}[0-9]{1,2})}.*\]";


            var openBr = new Stack<int>();
            var lines = new List<string>();

            for (int i = 0; i < suitcase.Length; i++)
            {
                if (suitcase[i] == '{')
                {
                    openBr.Push(i);
                }
                else if (suitcase[i] == '}')
                {
                    var lenght = i - openBr.Peek() + 1;
                    var line = suitcase.Substring(openBr.Pop(), lenght);
                    lines.Add(line);
                }

                if (suitcase[i] == '[')
                {
                    openBr.Push(i);
                }
                else if (suitcase[i] == ']')
                {
                    var lenght = i - openBr.Peek() + 1;
                    var line = suitcase.Substring(openBr.Pop(), lenght);
                    lines.Add(line);
                }
            }

            var seats = new List<string>();

            foreach (var line in lines)
            {
                if (Regex.IsMatch(line, firPattern))
                {
                    Match match = Regex.Match(line, firPattern);

                    seats.Add(match.Groups[2].Value);

                }
                else if (Regex.IsMatch(line, secPattern))
                {
                    Match match = Regex.Match(line, secPattern);

                    seats.Add(match.Groups[2].Value);


                }
            }

            if (seats.Count > 2)
            {

                Console.WriteLine($"You are traveling to {destination} on seats B48 and F48.");
            }
            else
            {
                Console.WriteLine($"You are traveling to {destination} on seats {seats[0]} and {seats[1]}.");
            }


        }
    }
}
