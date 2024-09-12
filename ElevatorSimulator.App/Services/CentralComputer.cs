using ElevatorSimulator.App.Models.Contracts;
using ElevatorSimulator.App.Models;
using ElevatorSimulator.App.Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElevatorSimulator.App.Services
{
    public class CentralComputer : ICentralComputer
    {
        private readonly List<IElevator> _elevators;
        private readonly List<IFloor> _floors;

        public CentralComputer(List<IElevator> elevators, List<IFloor> floors)
        {
            _elevators = elevators;
            _floors = floors;
        }

        public IFloor GetFloor(int floorNumber)
        {
            return _floors.FirstOrDefault(x => x.Number == floorNumber);
        }

        public void RequestElevator(IFloor floor, RequestTypes requestType, int passegerCount)
        {
            floor.RequestElevator(new Request() { RequestType = requestType, Passangers = passegerCount });
        }

        public IRequest GetNextElevator(IFloor floor)
        {
            return floor.GetNextRequest();
        }

        public async Task<IElevator> GetNearestAvailableElevator(IFloor floor, IRequest request)
        {
            IElevator elevator = null;
            await Task.Run(() => {
                elevator = _elevators.OrderBy(x => x.DistanceToFloor(floor.Number))
                                                     .Where(x => x.HasCapacity(request.Passangers))
                                                     .FirstOrDefault();
            });

            return elevator;
        }

        public async Task MoveElevator(IFloor floor, RequestTypes requestType, IElevator elevator)
        {
            await elevator?.Move(floor.Number, requestType);
        }
    }
}
