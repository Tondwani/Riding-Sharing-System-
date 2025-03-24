using RideSharingSystem.Models;
using System.Collections.Generic;

namespace RideSharingSystem.Services
{
    public class AdminService
    {
        private List<Driver> _drivers = new List<Driver>();

        // View reports
        public void ViewReports()
        {
            Console.WriteLine("Total Rides: 100"); // Placeholder
            Console.WriteLine("Total Earnings: $5000"); // Placeholder
            Console.WriteLine("Average Rating: 4.5"); // Placeholder
        }

        // Flag low-rated drivers
        public void FlagLowRatedDrivers()
        {
            var lowRatedDrivers = _drivers.Where(d => d.Rating < 3.0).ToList();
            if (lowRatedDrivers.Any())
            {
                Console.WriteLine("Low-rated drivers:");
                foreach (var driver in lowRatedDrivers)
                {
                    Console.WriteLine($"Driver ID: {driver.Id}, Name: {driver.Name}, Rating: {driver.Rating}");
                }
            }
            else
            {
                Console.WriteLine("No low-rated drivers found.");
            }
        }
    }
}