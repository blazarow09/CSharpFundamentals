using System;

namespace Mankind
{
    public class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        protected string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (char.IsUpper(value[0]) == false)
                {
                    throw new ArgumentException($"Expected upper case letter! Argument: firstName");
                }

                if (value.Length < 4)
                {
                    throw new ArgumentException($"Expected length at least 4 symbols! Argument: firstName");
                }

                this.firstName = value;
            }
        }

        protected string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (char.IsUpper(value[0]) == false)
                {
                    throw new ArgumentException($"Expected upper case letter! Argument: lastName");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException($"Expected length at least 3 symbols! Argument: lastName");
                }
                this.lastName = value;
            }
        }
    }
}