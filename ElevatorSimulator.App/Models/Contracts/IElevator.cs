using System.Threading.Tasks;

namespace ElevatorSimulator.App.Models.Contracts
{
    public interface IElevator
    {
        int Id { get; set; }
        int MaximumCapacity { get; set; }
        int DistanceToFloor(int callingFloor);
        bool HasCapacity(int requiredCapacity);
        Task Move(int callingFloor, RequestTypes requestType);
    }
}
