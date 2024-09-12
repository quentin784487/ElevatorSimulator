using System;

namespace ElevatorSimulator.App.Exceptions
{
    public class ElevatorCapacityException : Exception
    {
        public ElevatorCapacityException(string message) : base(message)
        {
        }
    }
}
