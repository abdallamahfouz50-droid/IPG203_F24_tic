using System;

namespace VehicleSystem
{
    // Truck class inheriting from Vehicle
    public class Truck : Vehicle
    {
        // Private fields for encapsulation
        private double loadCapacity;
        private bool hasTrailer;

        // Properties for encapsulation
        public double LoadCapacity
        {
            get { return loadCapacity; }
            set
            {
                if (value > 0)
                    loadCapacity = value;
                else
                    throw new ArgumentException("Load capacity must be positive");
            }
        }

        public bool HasTrailer
        {
            get { return hasTrailer; }
            set { hasTrailer = value; }
        }

        // Constructor
        public Truck(string make, string model, int year, double loadCapacity, bool hasTrailer)
            : base(make, model, year)
        {
            LoadCapacity = loadCapacity;
            HasTrailer = hasTrailer;
        }

        // Override abstract methods
        public override int GetMaxSpeed()
        {
            return 120; // Trucks typically max at 120 km/h
        }

        public override int GetWheelCount()
        {
            return HasTrailer ? 10 : 6; // 6 wheels normally, 10 with trailer
        }

        public override int GetSeatCount()
        {
            return 2; // Standard truck seating
        }

        // Override description method
        public override string GetDescription()
        {
            string trailerInfo = HasTrailer ? " with trailer" : "";
            return $"{base.GetDescription()} - {LoadCapacity}t capacity{trailerInfo}";
        }

        // Override honk method
        public override void Honk()
        {
            Console.WriteLine($"{Make} {Model}: Loud horn! Honk! Honk!");
        }



        // Override accelerate method for trucks (slower acceleration)
        public override void Accelerate(int speed)
        {
            if (IsRunning)
            {
                int truckSpeed = Math.Max(0, Math.Min(speed, GetMaxSpeed()));
                // Trucks accelerate slower
                Speed = truckSpeed > 80 ? truckSpeed - 10 : truckSpeed;
                Console.WriteLine($"{Make} {Model} accelerated to {Speed} km/h (truck speed).");
            }
        }

        // Additional method specific to trucks
        public void LoadCargo(double weight)
        {
            if (weight <= LoadCapacity)
                Console.WriteLine($"{Make} {Model}: Loaded {weight}t of cargo.");
            else
                Console.WriteLine($"{Make} {Model}: Cannot load {weight}t. Exceeds capacity of {LoadCapacity}t.");
        }
    }
}
