//using RideSharingSystem.Models;
//using RideSharingSystem.Services;
//using RideSharingSystem.Utilities;

//namespace RideSharingSystem.Menus
//{
//    public static class AdminMenu
//    {
//        public static void Display(Admin admin)
//        {
//            var adminService = new AdminService();

//            while (true)
//            {
//                Console.WriteLine("\n--- Admin Menu ---");
//                Console.WriteLine("1. View Reports");
//                Console.WriteLine("2. Flag Low-Rated Drivers");
//                Console.WriteLine("3. Logout");

//                int choice = InputHelper.GetIntegerInput("Enter your choice: ");

//                switch (choice)
//                {
//                    case 1:
//                        adminService.ViewReports();
//                        break;
//                    case 2:
//                        adminService.FlagLowRatedDrivers();
//                        break;
//                    case 3:
//                        Console.WriteLine("Logging out...");
//                        return;
//                    default:
//                        Console.WriteLine("Invalid choice. Please try again.");
//                        break;
//                }
//            }
//        }
//    }
//}