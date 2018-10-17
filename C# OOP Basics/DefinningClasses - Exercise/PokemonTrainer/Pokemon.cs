namespace PokemonTrainer
{
    public class Pokemon
    {
        private string name;
        private string element;
        private int health;

        public int Health
        {
            get { return health; }
            private set { health = value; }
        }

        public string Element
        {
            get { return element; }
            private set { element = value; }
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public Pokemon(string name, string element, int health)
        {
            this.Name = name;
            this.Element = element;
            this.Health = health;
        }

        public void ReduceHealth()
        {
            this.Health -= 10;
        }
    }
}