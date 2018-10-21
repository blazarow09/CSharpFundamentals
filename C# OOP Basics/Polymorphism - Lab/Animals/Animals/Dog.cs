using System;
namespace Animals
{

    public class Dog : Animal
    {
        public Dog(string name, string favouriteFood) : base(name, favouriteFood)
        {
        }

        public Dog(string name, string favouriteFood, string gender) : base(name, favouriteFood, gender)
        {
            
        }

        public string ExplainMyselft()
        {
            return $"Dog {base.Name} is a {base.Gender} and it's favourite food is {base.FavouriteFood}" + Environment.NewLine + "Rawrrr!";
        }


    }
}