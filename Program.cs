using RideSharingSystem.Menus;
using RideSharingSystem.Services;
using RideSharingSystem.Utilities;

namespace RideSharingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize services
            var userService = new UserService();
            var rideService = new RideService();
            var paymentService = new PaymentService();
            var adminService = new AdminService();

            // Main loop
            while (true)
            {
                // Display the main menu
                MainMenu.Display();

                // Get user input
                var choice = InputHelper.GetIntegerInput("Enter your choice: ");

                switch (choice)
                {
                    case 1:
                        // Register as Passenger
                        userService.RegisterPassenger();
                        break;
                    case 2:
                        // Register as Driver
                        userService.RegisterDriver();
                        break;
                    case 3:
                        // Login
                        var user = userService.Login();
                        if (user != null)
                        {
                            if (user is Models.Passenger)
                            {
                                PassengerMenu.Display(user as Models.Passenger, rideService, paymentService);
                            }
                            else if (user is Models.Driver)
                            {
                                DriverMenu.Display(user as Models.Driver, rideService, paymentService);
                            }
                            else if (user is Models.Admin)
                            {
                                AdminMenu.Display(user as Models.Admin, adminService);
                            }
                        }
                        break;
                    case 4:
                        // Exit
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