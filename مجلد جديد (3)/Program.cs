using System;

namespace VehicleSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Vehicle Management System Demo ===\n");

            // Create a vehicle manager
            VehicleManager fleet = new VehicleManager();

            // Create different types of vehicles
            Console.WriteLine("Creating vehicles...");

            // Create a car
            Car sedan = new Car("Toyota", "Camry", 2020, 4, "Gasoline");
            fleet.AddVehicle(sedan);

            // Create a truck
            Truck pickup = new Truck("Ford", "F-150", 2019, 1.5, true);
            fleet.AddVehicle(pickup);

            // Create a motorcycle
            Motorcycle sportBike = new Motorcycle("Honda", "CBR600", 2021, false, "Sport");
            fleet.AddVehicle(sportBike);

            // Create another car
            Car suv = new Car("Tesla", "Model X", 2022, 4, "Electric");
            fleet.AddVehicle(suv);

            // Create another motorcycle
            Motorcycle cruiser = new Motorcycle("Harley-Davidson", "Street Glide", 2018, true, "Cruiser");
            fleet.AddVehicle(cruiser);

            Console.WriteLine($"\nTotal vehicles in fleet: {fleet.VehicleCount}");
            Console.WriteLine($"Total wheels in fleet: {fleet.GetTotalWheelCount()}");
            Console.WriteLine($"Total seats in fleet: {fleet.GetTotalSeatCount()}");

            // Demonstrate static utility methods
            Console.WriteLine("\n=== Using Static Utility Methods ===");
            Console.WriteLine($"Sedan age: {VehicleUtils.CalculateAge(sedan.Year)} years");
            Console.WriteLine($"Sedan category: {VehicleUtils.GetVehicleCategory(sedan.GetWheelCount(), sedan.GetSeatCount())}");
            Console.WriteLine($"Truck estimated value: ${VehicleUtils.CalculateEstimatedValue(60000, VehicleUtils.CalculateAge(pickup.Year)):F2}");

            // Demonstrate events and delegates
            Console.WriteLine("\n=== Demonstrating Events ===");
            // Subscribe to vehicle events
            sedan.VehicleStarted += OnVehicleStarted;
            pickup.VehicleStarted += OnVehicleStarted;
            sportBike.VehicleStarted += OnVehicleStarted;

            // Start vehicles
            fleet.StartAllVehicles();

            // Accelerate vehicles
            fleet.AccelerateAllVehicles();

            // Make vehicles honk (demonstrates polymorphism)
            fleet.MakeAllVehiclesHonk();

            // Demonstrate specific vehicle behaviors
            Console.WriteLine("\n=== Demonstrating Specific Vehicle Behaviors ===");
            sedan.OpenTrunk();
            pickup.LoadCargo(2.0);
            sportBike.Wheelie();

            // Find vehicles by make
            Console.WriteLine("\n=== Finding Vehicles by Make ===");
            var hondaVehicles = fleet.FindVehiclesByMake("Honda");
            Console.WriteLine($"Found {hondaVehicles.Count} Honda vehicles:");
            foreach (var vehicle in hondaVehicles)
            {
                Console.WriteLine($"  - {vehicle.GetDescription()}");
            }

            // Display all vehicle details
            fleet.DisplayAllVehicles();

            // Stop all vehicles
            fleet.StopAllVehicles();

            // Demonstrate removing a vehicle
            Console.WriteLine("\n=== Removing a Vehicle ===");
            fleet.RemoveVehicle(sportBike);

            Console.WriteLine($"\nFinal vehicle count: {fleet.VehicleCount}");

            Console.WriteLine("\n=== Demo Complete ===");
        }

        // Event handler for vehicle started
        static void OnVehicleStarted(string message)
        {
            Console.WriteLine($"[EVENT] {message}");
        }
    }
}
