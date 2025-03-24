using RideSharingSystem.Data;  
using RideSharingSystem.Interfaces;
using RideSharingSystem.Models;
using RideSharingSystem.Utilities;

namespace RideSharingSystem.Services
{
    public class PaymentService : IPayable
    {
        public void AddFunds(int userId, decimal amount)
        {
            var user = Database.GetUserById(userId);  
            if (user is Passenger passenger)
            {
                passenger.Wallet.AddFunds(amount);
                Console.WriteLine($"Successfully added {amount:C} to your wallet. New balance: {passenger.Wallet.Balance:C}");
            }
            else
            {
                Console.WriteLine("Only passengers can add funds to their wallet.");
            }
        }

        public bool DeductFunds(int userId, decimal amount)
        {
            var user = Database.GetUserById(userId);  
            if (user is Passenger passenger)
            {
                if (passenger.Wallet.DeductFunds(amount))
                {
                    Console.WriteLine($"Deducted {amount:C} from your wallet. New balance: {passenger.Wallet.Balance:C}");
                    return true;
                }
                Console.WriteLine("Insufficient balance.");
                return false;
            }
            Console.WriteLine("Only passengers can deduct funds from their wallet.");
            return false;
        }
    }
}