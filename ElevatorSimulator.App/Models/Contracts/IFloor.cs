namespace ElevatorSimulator.App.Models.Contracts
{
    public interface IFloor
    {
        int Number { get; }
        void RequestElevator(IRequest request);
        IRequest GetNextRequest();
    }
}
