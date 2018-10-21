using System;
namespace Animals
{

    public class Cat : Animal
    {
        public Cat(string name, string favouriteFood) : base(name, favouriteFood)
        {
        }

        public string ExplainMyselft()
        {
            return "Cat" + base.ExplainMyselft() + Environment.NewLine + "Meowwwwwwwwwww";
        }
    }
}