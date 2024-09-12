using ElevatorSimulator.App.Models.Contracts;
using System.Collections.Generic;

namespace ElevatorSimulator.App.Models
{
    public class Floor : IFloor
    {
        public int Number { get; private set; }
        private readonly Queue<IRequest> Requests;

        public Floor(int number)
        {
            Number = number;
            Requests = new Queue<IRequest>();
        }

        public void RequestElevator(IRequest request)
        {
            Requests.Enqueue(request);
        }

        public IRequest GetNextRequest()
        {
            return Requests.Count > 0 ? Requests.Dequeue() : null;
        }
    }
}
