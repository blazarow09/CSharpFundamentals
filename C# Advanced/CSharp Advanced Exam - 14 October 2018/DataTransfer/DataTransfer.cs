namespace DataTransfer
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class DataTransfer
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());

            string pattern = "s:(?<sender>[^;]+);r:(?<receiver>[^;]+);m--\"(?<message>[a-zA-Z ]+)\"";

            var dataTransfer = 0;

            for (int i = 0; i < N; i++)
            {
                var line = Console.ReadLine();

                if (Regex.IsMatch(line, pattern))
                {

                    Match match = Regex.Match(line, pattern);

                    var mixSender = match.Groups["sender"].Value;
                    var mixReceiver = match.Groups["receiver"].Value;
                    var message = match.Groups["message"].Value;

                    var sender = "";
                    var receiver = "";

                    foreach (var ch in mixSender)
                    {
                        if (char.IsWhiteSpace(ch))
                        {
                            sender += ch;
                            continue;
                        }

                        if (char.IsLetter(ch))
                        {
                            sender += ch;
                        }

                        if (char.IsDigit(ch))
                        {
                            int val = (int)Char.GetNumericValue(ch);
                            dataTransfer += val;
                        }
                    }

                    foreach (var ch in mixReceiver)
                    {
                        if (char.IsWhiteSpace(ch))
                        {
                            receiver += ch;
                            continue;
                        }

                        if (char.IsLetter(ch))
                        {
                            receiver += ch;
                        }

                        if (char.IsDigit(ch))
                        {
                            int val = (int)Char.GetNumericValue(ch);
                            dataTransfer += val;
                        }
                    }

                    Console.WriteLine($"{sender} says \"{message}\" to {receiver}");
                }
            }

            Console.WriteLine($"Total data transferred: {dataTransfer}MB");
        }
    }
}
