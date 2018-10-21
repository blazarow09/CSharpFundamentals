namespace Animals.Animal
{
    internal class Dog : Animall
    {
        public const string Species = "Dog";

        public Dog(string name, string age, string gender) : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return Sounds.DogSound;
        }

        public override string ToString()
        {
            return $"{Species}\n{base.Name} {base.Age} {base.Gender}";
        }
    }
}