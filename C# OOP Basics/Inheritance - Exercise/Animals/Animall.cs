using System;

namespace Animals
{
    internal class Animall
    {
        private string name;
        private string age;
        private string gender;

        public Animall(string name, string age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidInputMessage);
                }

                this.name = value;
            }
        }

        public string Age
        {
            get
            {
                return this.age;
            }
            set
            {
                int output;

                bool canBeParsed = int.TryParse(value, out output);
                if (string.IsNullOrEmpty(value) || !canBeParsed || output < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidInputMessage);
                }

                this.age = value;
            }
        }

        public string Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !(value.ToLower() == "male" || value.ToLower() == "female"))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidInputMessage);
                }

                this.gender = value;
            }
        }

        public virtual string ProduceSound()
        {
            return Sounds.AnimalSound;
        }
    }
}