using RideSharingSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace RideSharingSystem.Data
{
    public static class Database
    {
        // In-memory storage for users
        public static List<User> Users { get; } = new List<User>();

        // In-memory storage for rides
        public static List<Ride> Rides { get; } = new List<Ride>();

        // In-memory storage for drivers
        public static List<Driver> Drivers { get; } = new List<Driver>();

        // Method to add a user
        public static void AddUser(User user)
        {
            Users.Add(user);
            if (user is Driver driver)
            {
                Drivers.Add(driver);
            }
        }

        // Method to get a user by ID
        public static User? GetUserById(int id)
        {
            return Users.FirstOrDefault(u => u.Id == id);
        }

        // Method to add a ride
        public static void AddRide(Ride ride)
        {
            Rides.Add(ride);
        }

        // Method to get a ride by ID
        public static Ride? GetRideById(int id)
        {
            return Rides.FirstOrDefault(r => r.Id == id);
        }

        public static List<Ride> GetRidesByDriver(int driverId)
        {
            return Rides.Where(r => r.DriverId == driverId).ToList();
        }

        // Method to get all available rides
        public static List<Ride> GetAvailableRides()
        {
            return Rides.Where(r => r.Status == "Requested").ToList();
        }

        public static void UpdateRide(Ride updatedRide)
        {
            var existing = Rides.FirstOrDefault(r => r.Id == updatedRide.Id);
            if (existing != null)
            {
                Rides.Remove(existing);
                Rides.Add(updatedRide);
            }
        }

        internal static Driver GetDriverById(int value)
        {
            throw new NotImplementedException();
        }
    }
}