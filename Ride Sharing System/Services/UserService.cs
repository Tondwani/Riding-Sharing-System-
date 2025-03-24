using RideSharingSystem.Models;
using RideSharingSystem.Utilities;
using System.Collections.Generic;

namespace RideSharingSystem.Services
{
    public class UserService
    {
        private List<User> _users = new List<User>();
        private int _nextUserId = 1;

        // Register a new passenger
        public void RegisterPassenger()
        {
            Console.WriteLine("Register as Passenger");
            string name = InputHelper.GetStringInput("Enter your name: ");
            string email = InputHelper.GetStringInput("Enter your email: ");
            string password = InputHelper.GetStringInput("Enter your password: ");

            var passenger = new Passenger(_nextUserId++, name, email, password);
            _users.Add(passenger);
            Console.WriteLine("Passenger registered successfully!");
        }

        // Register a new driver
        public void RegisterDriver()
        {
            Console.WriteLine("Register as Driver");
            string name = InputHelper.GetStringInput("Enter your name: ");
            string email = InputHelper.GetStringInput("Enter your email: ");
            string password = InputHelper.GetStringInput("Enter your password: ");

            var driver = new Driver(_nextUserId++, name, email, password);
            _users.Add(driver);
            Console.WriteLine("Driver registered successfully!");
        }

        // Register a new admin (optional)
        public void RegisterAdmin()
        {
            Console.WriteLine("Register as Admin");
            string name = InputHelper.GetStringInput("Enter your name: ");
            string email = InputHelper.GetStringInput("Enter your email: ");
            string password = InputHelper.GetStringInput("Enter your password: ");

            var admin = new Admin(_nextUserId++, name, email, password);
            _users.Add(admin);
            Console.WriteLine("Admin registered successfully!");
        }

        // Login
        public User Login()
        {
            string email = InputHelper.GetStringInput("Enter your email: ");
            string password = InputHelper.GetStringInput("Enter your password: ");

            var user = _users.Find(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                Console.WriteLine("Login successful!");
                return user;
            }
            else
            {
                Console.WriteLine("Invalid email or password.");
                return null;
            }
        }
    }
}