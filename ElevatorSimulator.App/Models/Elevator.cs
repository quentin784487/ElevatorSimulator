using ElevatorSimulator.App.Models.Contracts;
using System;
using System.Threading.Tasks;

namespace ElevatorSimulator.App.Models
{
    public class Elevator : IElevator
    {
        public int Id { get; set; }
        public int MaximumCapacity { get; set; }
        private int CurrentFloor;
        private int Speed;
        private int CurrentCapacity;        
        private string Name;

        public Elevator(int id, string name, int speed, int capacity)
        {
            Id = id;
            Name = name;
            Speed = speed;
            CurrentCapacity = capacity;
            MaximumCapacity = capacity;
        }

        public int DistanceToFloor(int callingFloor)
        {
            return Math.Abs(CurrentFloor - callingFloor);
        }

        public bool HasCapacity(int requiredCapacity)
        {
            return (CurrentCapacity - requiredCapacity) >= 0;
        }

        public async Task Move(int callingFloor, RequestTypes requestType)
        {
            Console.WriteLine($"\n{Name} moving from floor {CurrentFloor} to floor {callingFloor}. Direction: " + (CurrentFloor < callingFloor ? "UP\n" : "DOWN\n"));

            while (CurrentFloor != callingFloor)
            {
                CurrentFloor += (callingFloor > CurrentFloor) ? 1 : -1;
                Console.WriteLine($"{Name} is now at floor {CurrentFloor}");
                await Task.Delay(Speed);
            }

            if (requestType == RequestTypes.DISPATCH)
                CurrentCapacity = MaximumCapacity;

            Console.WriteLine($"\n{Name} has arrived at floor {callingFloor}\n");
        }
    }
}
