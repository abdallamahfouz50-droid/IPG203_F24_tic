using System;

namespace VehicleSystem
{
    // Car class inheriting from Vehicle
    public class Car : Vehicle
    {
        // Private fields for encapsulation
        private int doors;
        private string fuelType;

        // Properties for encapsulation
        public int Doors
        {
            get { return doors; }
            set
            {
                if (value >= 2 && value <= 5)
                    doors = value;
                else
                    throw new ArgumentException("Cars typically have 2-5 doors");
            }
        }

        public string FuelType
        {
            get { return fuelType; }
            set { fuelType = value; }
        }

        // Constructor
        public Car(string make, string model, int year, int doors, string fuelType)
            : base(make, model, year)
        {
            Doors = doors;
            FuelType = fuelType;
        }

        // Override abstract methods
        public override int GetMaxSpeed()
        {
            return 200; // Cars typically max at 200 km/h
        }

        public override int GetWheelCount()
        {
            return 4;
        }

        public override int GetSeatCount()
        {
            return 5; // Standard car seating
        }

        // Override description method
        public override string GetDescription()
        {
            return $"{base.GetDescription()} - {Doors}-door {FuelType} car";
        }

        // Override honk method
        public override void Honk()
        {
            Console.WriteLine($"{Make} {Model}: Honk! Honk!");
        }

        // Additional method specific to cars
        public void OpenTrunk()
        {
            Console.WriteLine($"{Make} {Model}: Trunk opened.");
        }
    }
}
