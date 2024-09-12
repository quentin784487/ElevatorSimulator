# Elevator Simulator

***

**The following console application simulates the movement of multiple elevators in a building.**

**The user will be able to instruct an elevator to do the following:**

1. Call an elevator to a specific floor by entering a floor number and amount of people waiting on the floor.
2. Dispatch the elevator to a specific floor

**The elevator management system has the following intelligence:**

1. Choose the nearest elevator for the calling floor
2. Choose an elevator that has sufficient capacity based on the amount of people waiting
3. Validate user input for floor selection, elevator selection and available capacity

## Class structure

## 1. Models

* Elevator
* Floor
* FreightElevator
* GlassElevator
* HighSpeedElevator
* Request
* ServiceTests

## 2. Interfaces

* IElevator
* IFloor
* IRequest
* ICentralComputer

## 3. Services

* CentralComputer

## 4. Enums

* RequestTypes

## 5. Exceptions

* ElevatorCapacityException
* InvalidFloorException
* InvalidInputException