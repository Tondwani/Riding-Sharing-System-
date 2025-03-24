using RideSharingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideSharingSystem.Interfaces
{
    public interface IRideable
    {
        void RequestRide(int passengerId, string pickupLocation, string dropoffLocation);
        void AcceptRide(int driverId, int rideId);
        void CompleteRide(int rideId);
        decimal CalculateFare(string pickupLocation, string dropoffLocation);
        List<Driver> GetNearbyDrivers(string passengerLocation);
    }
}

