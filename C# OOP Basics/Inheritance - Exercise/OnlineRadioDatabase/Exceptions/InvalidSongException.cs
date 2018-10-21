using System;

namespace OnlineRadioDatabase.Exceptions
{
    public class InvalidSongException : ArgumentException
    {
        private const string Message = "Invalid song.";

        public InvalidSongException()
            : base(Message)
        {
        }

        public InvalidSongException(string message)
            : base(message)
        {
        }
    }
}