namespace Animals.Animal
{
    internal class Tomcat : Cat
    {
        public new const string Species = "Tomcat";
        public const string TheGender = "Male";

        public Tomcat(string name, string age, string gender) : base(name, age, TheGender)
        {
        }

        public override string ProduceSound()
        {
            return Sounds.TomcatSound;
        }

        public override string ToString()
        {
            return $"{Species}\n {base.Name} {base.Age} {base.Gender}";
        }
    }
}