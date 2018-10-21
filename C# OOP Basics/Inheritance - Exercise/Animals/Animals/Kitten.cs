namespace Animals.Animal
{
    internal class Kitten : Cat
    {
        public new const string Species = "Kitten";
        public const string TheGender = "Female";

        public Kitten(string name, string age, string gender) : base(name, age, TheGender)
        {
        }

        public override string ProduceSound()
        {
            return Sounds.KittenSound;
        }

        public override string ToString()
        {
            return $"{Species}\n{base.Name} {base.Age} {base.Gender}";
        }
    }
}