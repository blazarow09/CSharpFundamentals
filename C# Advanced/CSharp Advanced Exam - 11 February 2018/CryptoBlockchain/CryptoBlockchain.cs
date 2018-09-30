namespace CryptoBlockchain
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    class CryptoBlockchain
    {
        static void Main(string[] args)
        {
            var cryptoBlock = string.Empty;
            var result = string.Empty;

            var pattern = @"\[[^\[\]{}]*?([0-9]{3,})[^\[\]{}]*?\]|{[^{}\]\[]*?([0-9]{3,})[^{}\]\[]*?}";
            var linesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesCount; i++)
            {
                var line = Console.ReadLine();

                cryptoBlock = String.Concat(cryptoBlock, line);
            }

            var matches = Regex.Matches(cryptoBlock, pattern);

            for (int i = 0; i < matches.Count; i++)
            {
                int groupNumber = matches[i].Groups[1].ToString() == String.Empty ? 2 : 1;

                var numsLength = matches[i]
                    .Groups[groupNumber]
                    .ToString()
                    .Length;
                
                if(numsLength % 3 == 0)
                {
                    int totalLength = matches[i]
                        .Groups[0]
                        .ToString()
                        .Length;

                    for (int j = 0; j < numsLength / 3; j++)
                    {
                        var temp = matches[i]
                            .Groups[groupNumber]
                            .ToString()
                            .Skip(3 * j)
                            .Take(3);

                        string ch = String.Concat(temp);
                        int currCode = int.Parse(ch);

                        currCode -= totalLength;

                        result = String.Concat(result, (char)currCode);
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
