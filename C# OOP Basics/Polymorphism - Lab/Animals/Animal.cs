using Animals.Exceptions;
using System;

namespace Animals
{
    public class Animal
    {
        private string name;
        private string favouriteFood;
        private string gender = "n/a";

        public Animal(string name, string favouriteFood)
        {
            this.Name = name;
            this.FavouriteFood = favouriteFood;
        }

        public Animal(string name, string favouriteFood, string gender)
        {
            this.Name = name;
            this.FavouriteFood = favouriteFood;
            this.Gender = gender;
        }

        protected string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value.Length < 3 || string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidNameException();
                }

                this.name = value;
            }
        }

        protected string FavouriteFood
        {
            get
            {
                return this.favouriteFood;
            }
            private set
            {
                if (value.Length < 3 || string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidFoodException();
                }

                this.favouriteFood = value;
            }
        }

        protected string Gender
        {
            get
            {
                return this.gender;
            }
            private set
            {
                this.gender = value;
            }

        }

        public string ExplainMyselft()
        {
            return $"{GetType()} {this.Name}'s favourite food is {this.FavouriteFood}" + Environment.NewLine + "Rawrrr!";
        }

    }
}