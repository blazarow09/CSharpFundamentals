using System;

namespace Animals
{
    public class Fish : Animal
    {
        public Fish(string name, string favouriteFood) : base(name, favouriteFood)
        {
        }

        public string ExplainMyselft()
        {
            return "Fish" + base.ExplainMyselft() + Environment.NewLine + "Duhai!";
        }
    }
}