namespace RectangleIntersection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static void Main(string[] args)
        {
            var tokens = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var rectangleNums = int.Parse(tokens[0]);
            var intersectionCount = int.Parse(tokens[1]);

            var rectangles = new List<Rectangle>();

            for (int i = 0; i < rectangleNums; i++)
            {
                var rectangleInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var id = rectangleInput[0];
                var width = double.Parse(rectangleInput[1]);
                var height = double.Parse(rectangleInput[2]);
                var x = double.Parse(rectangleInput[3]);
                var y = double.Parse(rectangleInput[4]);

                var rectangleInfo = new Rectangle(id, width, height, x, y);
                rectangles.Add(rectangleInfo);
            }

            for (int j = 0; j < intersectionCount; j++)
            {
                var cheks = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var firstId = cheks[0];
                string secondId = cheks[1];

                var firstRectangle = rectangles.First(r => r.Id == firstId);
                var secondRectangle = rectangles.First(r => r.Id == secondId);

                if (firstRectangle.IsIntersects(secondRectangle))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }
    }
}