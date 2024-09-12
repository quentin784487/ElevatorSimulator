using System;

namespace ElevatorSimulator.App.Exceptions
{
    public class InvalidFloorException : Exception
    {
        public InvalidFloorException() : base("Invalid floor.")
        {
        }
    }
}
