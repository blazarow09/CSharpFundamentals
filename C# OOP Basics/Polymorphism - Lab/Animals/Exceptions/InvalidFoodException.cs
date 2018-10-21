namespace Animals.Exceptions
{
    public class InvalidFoodException : InvalidInputException
    {
        public const string Message = "Food name is incorrect";

        public InvalidFoodException() : base(Message)
        {
        }

        public InvalidFoodException(string message) : base(message)
        {
        }
    }
}