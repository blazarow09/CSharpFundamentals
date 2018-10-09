namespace SoftUniExamResults
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SoftUniExamResults
    {
        static void Main(string[] args)
        {
            var participants = new Dictionary<string, int>();
            var submissions = new Dictionary<string, int>();

            var line = Console.ReadLine()
                .Split("-", StringSplitOptions.RemoveEmptyEntries);

            while (line[0] != "exam finished")
            {
                var name = line[0];

                if (line[1] == "banned")
                {
                    participants.Remove(name);
                }
                else
                {
                    var language = line[1];
                    var points = int.Parse(line[2]);

                    if (participants.ContainsKey(name) == false)
                    {
                        participants[name] = points;

                        if (submissions.ContainsKey(language) == false)
                        {
                            submissions[language] = 1;
                        }
                        else
                        {
                            submissions[language]++;
                        }
                    }
                    else
                    {
                        if (participants[name] < points)
                        {
                            participants[name] = points;

                            submissions[language]++;
                        }
                        else
                        {
                            if (submissions.ContainsKey(language) == false)
                            {
                                submissions[language] = 1;
                            }
                            else
                            {
                                submissions[language]++;
                            }
                        }
                    }
                }

                line = Console.ReadLine()
                .Split("-", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine("Results:");

            foreach (var name in participants.OrderByDescending(n => n.Value).ThenBy(v => v.Key))
            {
                Console.WriteLine($"{name.Key} | {name.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var sub in submissions.OrderByDescending(s => s.Value).ThenBy(l => l.Key))
            {
                Console.WriteLine($"{sub.Key} - {sub.Value}");
            }
        }
    }
}
