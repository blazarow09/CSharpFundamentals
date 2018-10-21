using System;
using System.Text.RegularExpressions;

namespace Mankind
{
    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber) : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        private string FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }
            set
            {
                if (!Regex.IsMatch(value, "^([A-Za-z\\d]{5,10})$"))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }

                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            return $"First Name: {base.FirstName}\n" +
                $"Last Name: {base.LastName}\n" +
                $"Faculty number: {this.FacultyNumber}";
        }
    }
}