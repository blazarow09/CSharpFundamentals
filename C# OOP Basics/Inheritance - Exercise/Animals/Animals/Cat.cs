namespace Animals.Animal
{
    internal class Cat : Animall
    {
        public const string Species = "Cat";

        public Cat(string name, string age, string gender) : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return Sounds.CatSound;
        }

        public override string ToString()
        {
            return $"{Species}\n{base.Name} {base.Age} {base.Gender}";
        }
    }
}