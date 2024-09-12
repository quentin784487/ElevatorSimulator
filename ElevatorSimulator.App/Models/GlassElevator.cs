namespace ElevatorSimulator.App.Models
{
    public class GlassElevator : Elevator
    {
        public GlassElevator(int id, int capacity) : base(id, "Glass Elevator", 1000, capacity)
        {
        }
    }
}
