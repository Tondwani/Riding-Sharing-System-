using RideSharingSystem.Data;
using RideSharingSystem.Models;
using RideSharingSystem.Services;
using RideSharingSystem.Utilities;


public static class PassengerMenu
{


    public static void Display(Passenger passenger, RideService rideService, PaymentService paymentService)
    {
        while (true)
        {
            Console.WriteLine("\n--- Passenger Menu ---");
            Console.WriteLine("1. Request a Ride");
            Console.WriteLine("2. View Wallet Balance");
            Console.WriteLine("3. Add Funds to Wallet");
            Console.WriteLine("4. View Ride History");
            Console.WriteLine("5. Rate a Driver");
            Console.WriteLine("6. Logout");

            int choice = InputHelper.GetIntegerInput("Enter your choice: ");

            switch (choice)
            {
                case 1:
                    string pickupLocation = InputHelper.GetStringInput("Enter pickup location: ");
                    string dropoffLocation = InputHelper.GetStringInput("Enter dropoff location: ");
                    rideService.RequestRide(passenger.Id, pickupLocation, dropoffLocation);

                    var drivers = rideService.GetNearbyDrivers(pickupLocation);
                    if (drivers.Any())
                    {
                        Console.WriteLine("Nearby drivers:");
                        foreach (var driver in drivers)
                        {
                            Console.WriteLine($"ID: {driver.Id}, Name: {driver.Name}, Rating: {driver.Rating}");
                        }
                        int driverId = InputHelper.GetIntegerInput("Enter driver ID to accept ride: ");
                        rideService.AcceptRide(driverId, passenger.Id);
                    }
                    else
                    {
                        Console.WriteLine("No drivers available nearby. Please try again later.");
                    }
                    break;

                case 2:

                    Console.WriteLine($"Wallet Balance: {passenger.Wallet.Balance}");
                    break;

                case 3: 
                    Console.WriteLine($"Current balance: {passenger.Wallet.Balance:C}");
                    decimal amount = InputHelper.GetDecimalInput("Enter amount to add: ");

                    if (amount > 0)
                    {
                        passenger.Wallet.AddFunds(amount);
                        Console.WriteLine($"Successfully added {amount:C}. New balance: {passenger.Wallet.Balance:C}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount. Please enter a positive number.");
                    }
                    break;

                case 4:
                    var rideHistory = Database.Rides
                        .Where(r => r.PassengerId == passenger.Id)
                        .ToList();
                    if (rideHistory.Any())
                    {
                        foreach (var historyRide in rideHistory)
                        {
                            Console.WriteLine($"ID: {historyRide.Id}, Pickup: {historyRide.PickupLocation}, " +
                                $"Dropoff: {historyRide.DropoffLocation}, Fare: {historyRide.Fare:C}, " +
                                $"Status: {historyRide.Status}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No ride history found.");
                    }
                    break;

                case 5:
                    int rideId = InputHelper.GetIntegerInput("Enter ride ID to rate: ");
                    var rideToRate = Database.GetRideById(rideId);
                    if (rideToRate != null && rideToRate.PassengerId == passenger.Id && rideToRate.Status == "Completed")
                    {
                        decimal rating = InputHelper.GetDecimalInput("Enter rating (1-5): ");
                        if (rating >= 1 && rating <= 5)
                        {
                            var driver = Database.GetDriverById(rideToRate.DriverId.Value);
                            if (driver != null)
                            {
                                driver.UpdateRating((int)rating);
                                Console.WriteLine("Driver rated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Driver not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid rating. Please enter a number between 1 and 5.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid ride ID or ride not completed yet.");
                    }
                    break;

                case 6:
                    Console.WriteLine("Logging out...");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}