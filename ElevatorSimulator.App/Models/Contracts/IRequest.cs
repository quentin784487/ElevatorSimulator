namespace ElevatorSimulator.App.Models.Contracts
{
    public interface IRequest
    {
        RequestTypes RequestType { get; set; }
        int Passangers { get; set; }
    }
}
