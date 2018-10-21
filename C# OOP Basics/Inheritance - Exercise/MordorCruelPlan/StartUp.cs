using MordorCruelPlan.Factories;
using MordorCruelPlan.Foods;
using System;
using System.Collections.Generic;

namespace MordorCruelPlan
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var foodTokens = Console.ReadLine()
                .Split(new char[] { '\t', ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            var foods = new List<Food>();
            var moodFactor = 0;

            foreach (var item in foodTokens)
            {
                foods.Add(FoodFactory.MakeFood(item));
            }

            foreach (var food in foods)
            {
                moodFactor += food.GetHappinessPoints();
            }

            Console.WriteLine(moodFactor);
            Console.WriteLine(MoodFactory.GetCorrespondingMood(moodFactor));
        }
    }
}