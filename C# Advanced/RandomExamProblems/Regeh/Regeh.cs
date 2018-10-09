namespace Regeh
{
    using System;
    using System.Text.RegularExpressions;

    class Regeh
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine();

            string pattern = @"\[[^/s+]*?.+?<(?<first>[0-9]+)REGEH(?<sec>[0-9]+)>.+?[^/s+]*?\]";

            MatchCollection matches = Regex.Matches(line, pattern);

            var word = "";

            foreach (Match match in matches)
            {
                var index = int.Parse(match.Groups["first"].Value);

                word += line[++index];

                index += int.Parse(match.Groups["sec"].Value);

                word += line[index];

                continue;
            }
        }
    }
}
