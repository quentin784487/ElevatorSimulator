using ElevatorSimulator.App.Exceptions;
using ElevatorSimulator.App.Models.Contracts;
using ElevatorSimulator.App.Models;
using ElevatorSimulator.App.Services.Contracts;
using ElevatorSimulator.App.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElevatorSimulator.App
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            const int MAX_CAPACITY = 10;

            var elevators = new List<IElevator>
                    {
                        new HighSpeedElevator(1, MAX_CAPACITY),
                        new GlassElevator(2, MAX_CAPACITY),
                        new FreightElevator(3, MAX_CAPACITY)
                    };

            var floors = new List<IFloor>
                    {
                        new Floor(0),
                        new Floor(1),
                        new Floor(2),
                        new Floor(3),
                        new Floor(4),
                        new Floor(5),
                        new Floor(6),
                        new Floor(7),
                        new Floor(8),
                        new Floor(9),
                        new Floor(10)
                    };

            ICentralComputer centralComputer = new CentralComputer(elevators, floors);
            IElevator elevator = null;
            int callingFloor = -1;
            int totalWaiting = 0;
            int requestedFloor = -1;

            while (true)
            {
                try
                {
                    if (callingFloor == -1)
                    {
                        Console.WriteLine("\nPlease indicate which floor you are on:");
                        var input = Console.ReadLine();

                        if (input.ToUpper() == "EXIT")
                            Environment.Exit(0);

                        if (int.TryParse(input, out int _callingFloor) && _callingFloor > 0)
                        {
                            var floor = centralComputer.GetFloor(_callingFloor);
                            if (floor == null)
                            {
                                callingFloor = -1;
                                throw new InvalidFloorException();
                            }

                            callingFloor = _callingFloor;
                        }
                        else
                        {
                            callingFloor = -1;
                            throw new InvalidInputException();
                        }
                    }

                    if (totalWaiting == 0)
                    {
                        Console.WriteLine("\nHow many people are waiting on your floor:");
                        var input = Console.ReadLine();

                        if (input.ToUpper() == "EXIT")
                            Environment.Exit(0);

                        if (int.TryParse(input, out int _totalWaiting) && _totalWaiting > 0)
                        {
                            var floor = centralComputer.GetFloor(callingFloor);

                            centralComputer.RequestElevator(floor, RequestTypes.CALL, _totalWaiting);
                            totalWaiting = _totalWaiting;

                            var request = centralComputer.GetNextElevator(floor);

                            elevator = await centralComputer.GetNearestAvailableElevator(floor, request);

                            if (elevator == null)
                            {
                                totalWaiting = 0;
                                throw new ElevatorCapacityException();
                            }
                            else
                                await centralComputer.MoveElevator(floor, RequestTypes.CALL, elevator);
                        }
                        else
                        {
                            totalWaiting = 0;
                            throw new InvalidInputException();
                        }
                    }

                    if (requestedFloor == -1)
                    {
                        Console.WriteLine("Please indicate your destination floor:");
                        var input = Console.ReadLine();

                        if (input.ToUpper() == "EXIT")
                            Environment.Exit(0);

                        if (int.TryParse(input, out int _requestedFloor) && _requestedFloor > 0)
                        {
                            var floor = centralComputer.GetFloor(_requestedFloor);
                            requestedFloor = _requestedFloor;

                            if (floor == null)
                            {
                                requestedFloor = -1;
                                throw new InvalidFloorException();
                            }
                            else
                            {
                                await centralComputer.MoveElevator(floor, RequestTypes.DISPATCH, elevator);

                                callingFloor = -1;
                                totalWaiting = 0;
                                requestedFloor = -1;                                
                            }
                        }
                        else
                        {
                            requestedFloor = -1;
                            throw new InvalidInputException();
                        }
                    }
                }
                catch (ElevatorCapacityException elevatorCapacityException)
                {
                    Console.WriteLine(elevatorCapacityException.Message);
                }
                catch (InvalidFloorException invalidFloorException)
                {
                    Console.WriteLine(invalidFloorException.Message);
                }
                catch (InvalidInputException invalidInputException)
                {
                    Console.WriteLine(invalidInputException.Message);
                }
                catch (Exception e)
                {
                    //Log exception stack
                }
            }
        }
    }
}
