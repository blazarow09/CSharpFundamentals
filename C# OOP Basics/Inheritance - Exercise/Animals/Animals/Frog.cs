namespace Animals.Animal
{
    internal class Frog : Animall
    {
        public const string Species = "Frog";

        public Frog(string name, string age, string gender) : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return Sounds.FrogSound;
        }

        public override string ToString()
        {
            return $"{Species}\n{base.Name} {base.Age} {base.Gender}";
        }
    }
}