namespace ElevatorSimulator.App.Models
{
    public class HighSpeedElevator : Elevator
    {
        public HighSpeedElevator(int id, int capacity) : base(id, "High Speed Elevator", 500, capacity)
        {
        }
    }
}
