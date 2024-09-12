using ElevatorSimulator.App.Models.Contracts;

namespace ElevatorSimulator.App.Models
{
    public class Request : IRequest
    {
        public RequestTypes RequestType { get; set; }
        public int Passangers { get; set; }
    }
}
