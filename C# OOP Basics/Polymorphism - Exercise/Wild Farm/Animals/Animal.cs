namespace _03.Wild_Farm
{
    public abstract class Animal
    {
        protected Animal(string name, string type, double weight)
        {
            this.Name = name;
            this.Type = type;
            this.Weight = weight;
        }

        public int FoodEaten { get; set; }

        public double Weight { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public abstract string MakeSound();

        public virtual void Eat(Food food)
        {
            this.FoodEaten += food.Quantity;
        }
    }
}
