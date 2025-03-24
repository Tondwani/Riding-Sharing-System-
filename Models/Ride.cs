using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideSharingSystem.Models
{
    public class Ride
    {
        public int Id { get; set; }
        public int PassengerId { get; set; }
        public int? DriverId { get; set; } // Nullable, as a driver may not have accepted the ride yet
        public string PickupLocation { get; set; }
        public string DropoffLocation { get; set; }
        public decimal Fare { get; set; }
        public string Status { get; set; } // e.g., "Requested", "Accepted", "Completed"

        // Constructor
        public Ride(int id, int passengerId, string pickupLocation, string dropoffLocation, decimal fare)
        {
            Id = id;
            PassengerId = passengerId;
            PickupLocation = pickupLocation;
            DropoffLocation = dropoffLocation;
            Fare = fare;
            Status = "Requested"; // Default status
        }
    }
}