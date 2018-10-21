using System;

namespace Animals.Exceptions
{
    public class InvalidInputException : ArgumentException
    {
        private const string Message = "Invalid input";

        public InvalidInputException() : base(Message)
        {
        }

        public InvalidInputException(string message) : base(message)
        {
        }
    }
}