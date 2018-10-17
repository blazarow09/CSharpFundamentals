namespace ValidationOfData
{
    public class Person
    {
        private string firstName;
        private int age;
        private decimal salary;

        public Person(string firstName, int age, decimal salary)
        {
            this.firstName = firstName;
            this.age = age;
            this.salary = salary;
        }

        public string FirstName
        {
            get { return this.firstName; }
        }

        public int Age
        {
            get { return this.age; }
        }

        public decimal Salary
        {
            get { return this.salary; }
        }
    }
}