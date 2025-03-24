using RideSharingSystem.Models;
using RideSharingSystem.Services;
using RideSharingSystem.Utilities;

namespace RideSharingSystem.Menus
{
    public static class MainMenu
    {
        public static void Display()
        {
            var userService = new UserService();
            var rideService = new RideService();
            var paymentService = new PaymentService();

            while (true)
            {
                Console.WriteLine("\n--- Main Menu ---");
                Console.WriteLine("1. Register as Passenger");
                Console.WriteLine("2. Register as Driver");
                Console.WriteLine("3. Login");
                Console.WriteLine("4. Exit");

                int choice = InputHelper.GetIntegerInput("Enter your choice: ");

                switch (choice)
                {
                    case 1:
                        userService.RegisterPassenger();
                        break;
                    case 2:
                        userService.RegisterDriver();
                        break;
                    case 3:


                    var user = userService.Login();
                        if (user != null)
                        {
                            if (user is Passenger passenger)
                            {
                                PassengerMenu.Display(passenger, rideService, paymentService);
                            }
                            else if (user is Driver driver)
                            {
                                DriverMenu.Display(driver);
                            }
                            else if (user is Admin admin)
                            {
                                AdminMenu.Display(admin);
                            }
                        }
                        break;
                    case 4:
                        Console.WriteLine("Exiting the application...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}