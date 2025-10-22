using System;

namespace VehicleSystem
{
    // Static class with utility methods for vehicles
    public static class VehicleUtils
    {
        // Static method to calculate vehicle age
        public static int CalculateAge(int year)
        {
            return DateTime.Now.Year - year;
        }

        // Static method to format vehicle info
        public static string FormatVehicleInfo(string make, string model, int year)
        {
            return $"{year} {make} {model}";
        }

        // Static method to determine vehicle type based on characteristics
        public static string GetVehicleCategory(int wheels, int seats)
        {
            if (wheels == 2)
                return "Motorcycle";
            else if (wheels == 4 && seats <= 5)
                return "Car";
            else if (wheels == 4 && seats > 5)
                return "Truck";
            else
                return "Other";
        }

        // Static method to calculate estimated value based on age
        public static double CalculateEstimatedValue(double originalPrice, int age)
        {
            // Simple depreciation calculation
            return originalPrice * Math.Pow(0.85, age);
        }
    }
}
