using ElevatorSimulator.App.Models.Contracts;
using ElevatorSimulator.App.Models;
using System.Threading.Tasks;

namespace ElevatorSimulator.App.Services.Contracts
{
    public interface ICentralComputer
    {
        IFloor GetFloor(int floorNumber);
        void RequestElevator(IFloor floor, RequestTypes requestType, int passegerCount);
        IRequest GetNextElevator(IFloor floor);
        Task<IElevator> GetNearestAvailableElevator(IFloor floor, IRequest request);
        Task MoveElevator(IFloor floor, RequestTypes requestType, IElevator elevator);
    }
}
