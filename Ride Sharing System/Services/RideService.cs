using RideSharingSystem.Data;
using RideSharingSystem.Interfaces;
using RideSharingSystem.Models;
using RideSharingSystem.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace RideSharingSystem.Services
{
    public class RideService : IRideable
    {
        private List<Ride> _rides = new List<Ride>();
        private List<Driver> _drivers = new List<Driver>();
        private int _nextRideId = 1;

        // Request a ride
        public void RequestRide(int passengerId, string pickupLocation, string dropoffLocation)
        {
            try
            {
                decimal fare = CalculateFare(pickupLocation, dropoffLocation);
                var ride = new Ride(_nextRideId++, passengerId, pickupLocation, dropoffLocation, fare);

                Database.AddRide(ride);
                Console.WriteLine($"Ride requested successfully! Fare: {fare:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // Get nearby drivers
        public List<Driver> GetNearbyDrivers(string passengerLocation)
        {
            return Database.Drivers
                .Where(d => d.AvailabilityStatus && d.Location == passengerLocation) // Filter by location and availability
                .ToList();
        }

        // Accept a ride
        public bool AcceptRide(int driverId, int rideId)
        {
            var ride = Database.GetRideById(rideId);
            if (ride != null && ride.Status == "Requested")
            {
                ride.DriverId = driverId;
                ride.Status = "Accepted";
                Database.UpdateRide(ride); 
                return true;
            }
            return false;
        }

        public bool CompleteRide(int driverId, int rideId)
        {
            var ride = Database.GetRideById(rideId);
            if (ride != null && ride.DriverId == driverId && ride.Status == "Accepted")
            {
                ride.Status = "Completed";
                Database.UpdateRide(ride);

                var driver = Database.GetDriverById(driverId);
                if (driver != null)
                {
                    driver.AddEarnings(ride.Fare);
                }
                return true;
            }
            return false;
        }

        // Calculate fare (simulated)
        private decimal CalculateFare(string pickupLocation, string dropoffLocation)
        {
            double distanceInKm = CalculateDistance(pickupLocation, dropoffLocation);
            decimal ratePerKm = 5.0m; 
            return (decimal)distanceInKm * ratePerKm;
        }

        // Simulate distance calculation
        private double CalculateDistance(string pickupLocation, string dropoffLocation)
        {
            return 10.0; // 10 km for demonstration
        }

        // Get available rides for drivers
        public List<Ride> GetAvailableRides()
        {
            return Database.Rides.Where(r => r.Status == "Requested").ToList();
        }

        decimal IRideable.CalculateFare(string pickupLocation, string dropoffLocation)
        {
            return CalculateFare(pickupLocation, dropoffLocation);
        }

        void IRideable.AcceptRide(int driverId, int rideId)
        {
            throw new NotImplementedException();
        }

        public void CompleteRide(int rideId)
        {
            throw new NotImplementedException();
        }
    }
}