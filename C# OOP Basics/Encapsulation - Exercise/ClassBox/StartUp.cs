namespace ClassBox
{
    using System;
    using System.Collections.Generic;

    internal class StartUp
    {
        private static void Main(string[] args)
        {
            var boxes = new List<Box>();

            var length = double.Parse(Console.ReadLine());

            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());

            var box = new Box();

            box.CalculateVolume(length, width, height);
            box.CalculateSurfaceArea(length, width, height);
            box.CalculateLateralSurfaceArea(length, width, height);
            boxes.Add(box);

            boxes.ForEach(x => Console.WriteLine(x));
        }
    }
}