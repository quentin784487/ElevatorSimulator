namespace ElevatorSimulator.App.Models
{
    public class FreightElevator : Elevator
    {
        public FreightElevator(int id, int capacity) : base(id, "Freight Elevator", 1500, capacity)
        {
        }
    }
}
