using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideSharingSystem.Models
{
    public class Driver : User
    {
        public bool AvailabilityStatus { get; set; }
        public double Rating { get; private set; }
        public int TotalRides { get; private set; }
        public decimal Earnings { get; private set; }
        public object Wallet { get; internal set; }

        public string Location { get; set; }

        // Constructor
        public Driver(int id, string name, string email, string password)
            : base(id, name, email, password)
        {
            AvailabilityStatus = false; // Default to unavailable
            Rating = 5.0; // Default rating
            TotalRides = 0;
            Earnings = 0;
        }

        // Method to update rating
        public void UpdateRating(double newRating)
        {
            Rating = (Rating * TotalRides + newRating) / (TotalRides + 1);
            TotalRides++;
        }

        // Method to add earnings
        public void AddEarnings(decimal amount)
        {
            Earnings += amount;
        }
    }
}

