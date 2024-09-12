using System;

namespace ElevatorSimulator.App.Exceptions
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException() : base("Invalid input. Please try again.")
        {
        }
    }
}
