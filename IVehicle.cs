namespace VehicleSystem
{
    // Interface defining core vehicle operations
    public interface IVehicle
    {
        // Method to start the vehicle
        void Start();

        // Method to stop the vehicle
        void Stop();

        // Method to accelerate
        void Accelerate(int speed);

        // Method to get current speed
        int GetCurrentSpeed();

        // Method to get vehicle description
        string GetDescription();

        // Event for when vehicle starts
        event VehicleEventHandler VehicleStarted;

        // Event for when vehicle stops
        event VehicleEventHandler VehicleStopped;
    }

    // Delegate for vehicle events
    public delegate void VehicleEventHandler(string message);
}
