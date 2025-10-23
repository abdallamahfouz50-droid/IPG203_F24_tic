using System;

namespace VehicleSystem
{
    // Abstract base class for all vehicles
    public abstract class Vehicle : IVehicle
    {
        // Private fields for encapsulation
        private string make;
        private string model;
        private int year;
        private int speed;
        private bool isRunning;

        // Properties for encapsulation
        public string Make
        {
            get { return make; }
            set { make = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int Year
        {
            get { return year; }
            set
            {
                if (value >= 1886 && value <= DateTime.Now.Year) // First car was in 1886
                    year = value;
                else
                    throw new ArgumentException("Invalid year");
            }
        }

        public int Speed
        {
            get { return speed; }
            protected set { speed = value; }
        }

        public bool IsRunning
        {
            get { return isRunning; }
            protected set { isRunning = value; }
        }

        // Constructor
        public Vehicle(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;
            Speed = 0;
            IsRunning = false;
        }

        // Event declarations
        public event VehicleEventHandler VehicleStarted;
        public event VehicleEventHandler VehicleStopped;

        // Interface methods implementation
        public virtual void Start()
        {
            if (!IsRunning)
            {
                IsRunning = true;
                Console.WriteLine($"{Make} {Model} started.");
                VehicleStarted?.Invoke($"{Make} {Model} has started.");
            }
        }

        public virtual void Stop()
        {
            if (IsRunning)
            {
                IsRunning = false;
                Speed = 0;
                Console.WriteLine($"{Make} {Model} stopped.");
                VehicleStopped?.Invoke($"{Make} {Model} has stopped.");
            }
        }

        public virtual void Accelerate(int speed)
        {
            if (IsRunning)
            {
                Speed = Math.Max(0, Math.Min(speed, GetMaxSpeed()));
                Console.WriteLine($"{Make} {Model} accelerated to {Speed} km/h.");
            }
        }

        public virtual int GetCurrentSpeed()
        {
            return Speed;
        }

        public virtual string GetDescription()
        {
            return VehicleUtils.FormatVehicleInfo(Make, Model, Year);
        }

        // Abstract methods to be implemented by derived classes
        public abstract int GetMaxSpeed();
        public abstract int GetWheelCount();
        public abstract int GetSeatCount();

        // Virtual method for honking (can be overridden)
        public virtual void Honk()
        {
            Console.WriteLine($"{Make} {Model}: Beep beep!");
        }
    }
}
