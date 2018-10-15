namespace Tagram
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Tagram
    {
        static void Main(string[] args)
        {
            var tagram = new Dictionary<string, Dictionary<string, int>>();

            var line = Console.ReadLine()
                .Split(new[] { " -> ", " " }, StringSplitOptions.RemoveEmptyEntries);

            while (line[0] != "end")
            {
                var username = line[0];

                if (line.Count() > 2)
                {
                    var tag = line[1];
                    var likes = int.Parse(line[2]);

                    if (tagram.ContainsKey(username) == false)
                    {
                        tagram[username] = new Dictionary<string, int>();

                        tagram[username].Add(tag, likes);
                    }
                    else if (tagram.ContainsKey(username) == true)
                    {
                        if (tagram[username].ContainsKey(tag) == false)
                        {
                            tagram[username].Add(tag, likes);
                        }
                        else
                        {
                            tagram[username][tag] += likes;
                        }
                    }
                }
                else
                {
                    var user = line[1];

                    if (tagram.ContainsKey(user) == true)
                    {
                        tagram.Remove(user);
                    }
                }

                line = Console.ReadLine()
                .Split(new[] { " -> ", " " }, StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var user in tagram.OrderByDescending(l => l.Value.Values.Sum()).ThenBy(t => t.Value.Count()))
            {
                Console.WriteLine($"{user.Key}");

                foreach (var tag in user.Value)
                {
                    Console.WriteLine($"- {tag.Key}: {tag.Value}");
                }
            }
        }
    }
}