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
        public int? DriverId { get; set; } 
        public string PickupLocation { get; set; }
        public string DropoffLocation { get; set; }
        public decimal Fare { get; set; }
        public string Status { get; set; } 

        public  int  rating { get; set; }

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