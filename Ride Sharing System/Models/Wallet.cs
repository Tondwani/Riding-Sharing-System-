using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideSharingSystem.Models
{
    public class Wallet
    {
        public decimal Balance { get; private set; }

        // Constructor
        public Wallet()
        {
            Balance = 0; // Default balance
        }

        // Method to add funds
        public void AddFunds(decimal amount)
        {

            if (amount > 0)
            {
                Balance += amount;
            }
        }

        // Method to deduct funds
        public bool DeductFunds(decimal amount)
        {
            if (amount > 0 && Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            return false; 
        }
    }
}

