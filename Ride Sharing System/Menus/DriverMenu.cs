using RideSharingSystem.Data;
using RideSharingSystem.Models;
using RideSharingSystem.Services;
using RideSharingSystem.Utilities;

namespace RideSharingSystem.Menus
{
    public static class DriverMenu
    {
        public static void Display(Driver driver)
        {
            var rideService = new RideService();
            var paymentService = new PaymentService();

            while (true)
            {
                Console.WriteLine("1. View Available Ride Requests");
                Console.WriteLine("2. Accept a Ride");
                Console.WriteLine("3. Complete a Ride");
                Console.WriteLine("4. View Earnings and Ride History");
                Console.WriteLine("5. Rate a Passenger");
                Console.WriteLine("6. Logout");

                int choice = InputHelper.GetIntegerInput("Enter your choice: ");

                switch (choice)
                {
                    case 1:
                        var availableRides = rideService.GetAvailableRides();
                        if (availableRides.Any())
                        {
                            Console.WriteLine("Available Rides:");
                            for (int i = 0; i < availableRides.Count; i++)
                            {
                                Console.WriteLine($"Ride ID: {availableRides[i].Id}, Pickup: {availableRides[i].PickupLocation}, Dropoff: {availableRides[i].DropoffLocation}, Fare: {availableRides[i].Fare}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No available rides.");
                        }
                        break;
                    case 2: 
                        int acceptRideId = InputHelper.GetIntegerInput("Enter Ride ID to accept: ");
                        if (rideService.AcceptRide(driver.Id, acceptRideId))
                        {
                            Console.WriteLine("Ride accepted successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Failed to accept ride. It may have been taken by another driver.");
                        }
                        break;

                    case 3: 
                        int completeRideId = InputHelper.GetIntegerInput("Enter Ride ID to complete: ");
                        if (rideService.CompleteRide(driver.Id, completeRideId))
                        {
                            Console.WriteLine("Ride completed successfully! Earnings added.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to complete ride. Make sure you've accepted this ride.");
                        }
                        break;

                    case 4: 
                        Console.WriteLine($"\nTotal Earnings: {driver.Earnings:C}");
                        var driverRides = Database.Rides
                            .Where(r => r.DriverId == driver.Id)
                            .OrderByDescending(r => r.Id)
                            .ToList();

                        if (driverRides.Any())
                        {
                            Console.WriteLine("\nYour Ride History:");
                            Console.WriteLine("ID\tFrom\t\tTo\t\tFare\tStatus");
                            foreach (var ride in driverRides)
                            {
                                Console.WriteLine($"{ride.Id}\t{ride.PickupLocation}\t{ride.DropoffLocation}\t" +
                                    $"{ride.Fare:C}\t{ride.Status}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No ride history found.");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Logging out...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }

            static decimal GetWalletBalance(Driver driver)
            {
                return ((Wallet)driver.Wallet).Balance;
            }
        }

        private static void NewMethod(List<Ride> driverRides)
        {
            foreach (var ride in driverRides)
            {
                Console.WriteLine($"{ride.Id}\t{ride.PickupLocation}\t{ride.DropoffLocation}\t" +
                    $"{ride.Fare:C}\t{ride.Status}");
            }
        }

        internal static void Display(Driver? driver, RideService rideService, PaymentService paymentService)
        {
            throw new NotImplementedException();
        }
    }
}