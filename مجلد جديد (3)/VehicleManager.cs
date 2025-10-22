using System;
using System.Collections.Generic;

namespace VehicleSystem
{
    // Manager class to handle a collection of vehicles
    public class VehicleManager
    {
        // List to store vehicles
        private List<Vehicle> vehicles;

        // Constructor
        public VehicleManager()
        {
            vehicles = new List<Vehicle>();
        }

        // Method to add a vehicle to the collection
        public void AddVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
            Console.WriteLine($"Added {vehicle.GetDescription()} to the fleet.");
        }

        // Method to remove a vehicle from the collection
        public bool RemoveVehicle(Vehicle vehicle)
        {
            bool removed = vehicles.Remove(vehicle);
            if (removed)
                Console.WriteLine($"Removed {vehicle.GetDescription()} from the fleet.");
            return removed;
        }

        // Method to find vehicles by make
        public List<Vehicle> FindVehiclesByMake(string make)
        {
            List<Vehicle> foundVehicles = new List<Vehicle>();
            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle.Make.Equals(make, StringComparison.OrdinalIgnoreCase))
                    foundVehicles.Add(vehicle);
            }
            return foundVehicles;
        }

        // Method to start all vehicles
        public void StartAllVehicles()
        {
            Console.WriteLine("\n--- Starting all vehicles ---");
            foreach (Vehicle vehicle in vehicles)
            {
                vehicle.Start();
            }
        }

        // Method to stop all vehicles
        public void StopAllVehicles()
        {
            Console.WriteLine("\n--- Stopping all vehicles ---");
            foreach (Vehicle vehicle in vehicles)
            {
                vehicle.Stop();
            }
        }

        // Method to display all vehicles
        public void DisplayAllVehicles()
        {
            Console.WriteLine("\n--- Vehicle Fleet ---");
            foreach (Vehicle vehicle in vehicles)
            {
                Console.WriteLine(vehicle.GetDescription());
                Console.WriteLine($"  Max Speed: {vehicle.GetMaxSpeed()} km/h");
                Console.WriteLine($"  Wheels: {vehicle.GetWheelCount()}");
                Console.WriteLine($"  Seats: {vehicle.GetSeatCount()}");
                Console.WriteLine($"  Age: {VehicleUtils.CalculateAge(vehicle.Year)} years");
                Console.WriteLine($"  Estimated Value: ${VehicleUtils.CalculateEstimatedValue(50000, VehicleUtils.CalculateAge(vehicle.Year)):F2}");
                Console.WriteLine();
            }
        }

        // Method to demonstrate polymorphism - make all vehicles honk
        public void MakeAllVehiclesHonk()
        {
            Console.WriteLine("\n--- All vehicles honking ---");
            foreach (Vehicle vehicle in vehicles)
            {
                vehicle.Honk();
            }
        }

        // Method to accelerate all vehicles to random speeds
        public void AccelerateAllVehicles()
        {
            Random random = new Random();
            Console.WriteLine("\n--- Accelerating all vehicles ---");
            foreach (Vehicle vehicle in vehicles)
            {
                int randomSpeed = random.Next(30, vehicle.GetMaxSpeed() + 1);
                vehicle.Accelerate(randomSpeed);
            }
        }

        // Method to get total wheel count of all vehicles
        public int GetTotalWheelCount()
        {
            int totalWheels = 0;
            foreach (Vehicle vehicle in vehicles)
            {
                totalWheels += vehicle.GetWheelCount();
            }
            return totalWheels;
        }

        // Method to get total seat count of all vehicles
        public int GetTotalSeatCount()
        {
            int totalSeats = 0;
            foreach (Vehicle vehicle in vehicles)
            {
                totalSeats += vehicle.GetSeatCount();
            }
            return totalSeats;
        }

        // Property to get the count of vehicles
        public int VehicleCount
        {
            get { return vehicles.Count; }
        }
    }
}
