namespace Animals.Exceptions
{
    public class InvalidNameException : InvalidInputException
    {
        public const string Message = "Name is incorrect";

        public InvalidNameException() : base(Message)
        {
        }

        public InvalidNameException(string message) : base(message)
        {
        }
    }
}