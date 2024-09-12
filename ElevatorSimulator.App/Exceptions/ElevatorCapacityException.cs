using System;

namespace ElevatorSimulator.App.Exceptions
{
    public class ElevatorCapacityException : Exception
    {
        public ElevatorCapacityException() : base("All elevators are currently at full capacity. Please try again.")
        {
        }
    }
}
