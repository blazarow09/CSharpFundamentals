namespace CupsAndBottles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] waterCups = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] waterAndBottles = Console.ReadLine().Split().Select(int.Parse).ToArray();

            List<int> cups = new List<int>();
            Stack<int> bottles = new Stack<int>();

            Push(waterCups, waterAndBottles, cups, bottles);

            while (true)
            {
                
                if (CheckWandBCount(cups, bottles))
                {
                    break;
                }

                if (cups[0] < bottles.Peek())
                {
                    if (bottles.Count < 0)
                    {
                        break;
                    }

                    int bottle = bottles.Pop();

                    if (cups.Count <= 0)
                    {
                        break;
                    }

                    int cup = cups[0];
                    cups.RemoveAt(0);

                    int left = bottle - cup;

                    if (left == 0)
                    {
                        if (bottles.Count < 0)
                        {
                            break;
                        }

                        continue;
                    }

                    if (bottles.Count <= 0)
                    {
                        bottles.Push(left);
                        continue;
                    }

                    int bottleToAdd = left + bottles.Pop();
                    bottles.Push(bottleToAdd);
                }
                else
                {
                    if (cups.Count < 0)
                    {
                        break;
                    }

                    int cup = cups[0];
                    cups.RemoveAt(0);

                    if (bottles.Count < 0)
                    {
                        break;
                    }

                    int bottle = bottles.Pop();

                    int left = cup - bottle;

                    if (cups.Count <= 0)
                    {
                        break;
                    }

                    if (left == 0)
                    {
                        if (cups.Count < 0)
                        {
                            break;
                        }

                        continue;
                    }

                    cups.Insert(0, left);
                }

                if (CheckWandBCount(cups, bottles))
                {
                    break;
                }
            }

            if (cups.Count > 0)
            {
                Console.WriteLine(string.Join(" ", cups));
            }

            if (bottles.Count > 0)
            {
                Console.WriteLine(string.Join(" ", bottles));
            }
        }

        private static bool CheckWandBCount(List<int> cups, Stack<int> bottles)
        {
            if (cups.Count <= 0 || bottles.Count <= 0)
            {
                return true;
            }

            return false;
        }

        private static void Push(int[] waterCups, int[] waterAndBottles, List<int> cups, Stack<int> bottles)
        {
            foreach (var cup in waterCups)
            {
                cups.Add(cup);
            }

            foreach (var bottle in waterAndBottles)
            {
                bottles.Push(bottle);
            }
        }
    }
}