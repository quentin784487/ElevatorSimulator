using ElevatorSimulator.App.Models;
using ElevatorSimulator.App.Models.Contracts;
using ElevatorSimulator.App.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElevatorSimulator.Tests
{
    [TestClass]
    public class ServiceTests
    {
        [TestMethod]
        public void GetFloor_Test()
        {
            // Arrange

            var floors = new List<IFloor>
                    {
                        new Floor(0),
                        new Floor(1),
                        new Floor(2)
                    };

            var centralComputer = new CentralComputer(null, floors);

            // Act

            var floor = centralComputer.GetFloor(1);

            // Assert

            Assert.AreEqual(floor.Number, 1);
        }

        [TestMethod]
        public void GetNextElevator_Test()
        {
            // Arrange

            var elevators = new List<IElevator>
                    {
                        new HighSpeedElevator(1, 10),
                        new GlassElevator(2, 10),
                        new FreightElevator(3, 10)
                    };

            var floors = new List<IFloor>
                    {
                        new Floor(0),
                        new Floor(1),
                        new Floor(2)
                    };

            var centralComputer = new CentralComputer(elevators, floors);

            // Act

            centralComputer.RequestElevator(floors.Where(x => x.Number == 2).First(), RequestTypes.CALL, 5);
            centralComputer.RequestElevator(floors.Where(x => x.Number == 1).First(), RequestTypes.CALL, 8);

            var request = centralComputer.GetNextElevator(floors.Where(x => x.Number == 1).First());

            // Assert

            Assert.AreNotEqual(request, null);
        }

        [TestMethod]
        public async Task GetNearestAvailableElevator_Test()
        {
            // Arrange

            var elevators = new List<IElevator>
                    {
                        new HighSpeedElevator(1, 10),
                        new GlassElevator(2, 10),
                        new FreightElevator(3, 10)
                    };

            var floors = new List<IFloor>
                    {
                        new Floor(0),
                        new Floor(1),
                        new Floor(2)
                    };

            // Act

            var centralComputer = new CentralComputer(elevators, floors);

            await centralComputer.MoveElevator(floors.Where(x => x.Number == 2).First(), RequestTypes.CALL, elevators.Where(x => x.Id == 1).First());
            await centralComputer.MoveElevator(floors.Where(x => x.Number == 2).First(), RequestTypes.CALL, elevators.Where(x => x.Id == 2).First());

            var request = new Request() { Passangers = 4, RequestType = RequestTypes.CALL };

            var elevator = await centralComputer.GetNearestAvailableElevator(floors.Where(x => x.Number == 0).First(), request);

            // Assert

            Assert.AreEqual(elevator, elevators.Where(x => x.Id == 3).First());
        }
    }
}
