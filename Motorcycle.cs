using System;

namespace VehicleSystem
{
    // Motorcycle class inheriting from Vehicle
    public class Motorcycle : Vehicle
    {
        // Private fields for encapsulation
        private bool hasSidecar;
        private string engineType;

        // Properties for encapsulation
        public bool HasSidecar
        {
            get { return hasSidecar; }
            set { hasSidecar = value; }
        }

        public string EngineType
        {
            get { return engineType; }
            set { engineType = value; }
        }

        // Constructor
        public Motorcycle(string make, string model, int year, bool hasSidecar, string engineType)
            : base(make, model, year)
        {
            HasSidecar = hasSidecar;
            EngineType = engineType;
        }

        // Override abstract methods
        public override int GetMaxSpeed()
        {
            return 250; // Motorcycles can go faster
        }

        public override int GetWheelCount()
        {
            return 2;
        }

        public override int GetSeatCount()
        {
            return HasSidecar ? 3 : 2; // 2 normally, 3 with sidecar
        }

        // Override description method
        public override string GetDescription()
        {
            string sidecarInfo = HasSidecar ? " with sidecar" : "";
            return $"{base.GetDescription()} - {EngineType} motorcycle{sidecarInfo}";
        }

        // Override honk method
        public override void Honk()
        {
            Console.WriteLine($"{Make} {Model}: Vroom! Vroom!");
        }

        // Additional method specific to motorcycles
        public void Wheelie()
        {
            if (IsRunning && Speed > 30)
                Console.WriteLine($"{Make} {Model}: Doing a wheelie!");
            else
                Console.WriteLine($"{Make} {Model}: Need to be moving faster for a wheelie!");
        }

        // Override accelerate method for motorcycles (faster acceleration)
        public override void Accelerate(int speed)
        {
            if (IsRunning)
            {
                int bikeSpeed = Math.Max(0, Math.Min(speed, GetMaxSpeed()));
                // Motorcycles accelerate faster
                Speed = Math.Min(bikeSpeed + 20, GetMaxSpeed());
                Console.WriteLine($"{Make} {Model} accelerated to {Speed} km/h (bike speed).");
            }
        }
    }
}
