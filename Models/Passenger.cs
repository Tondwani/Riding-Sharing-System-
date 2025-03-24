using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideSharingSystem.Models
{
    public class Passenger : User
    {
        public Wallet Wallet { get; set; }

        public string Location { get; set; }

        // Constructor
        public Passenger(int id, string name, string email, string password)
            : base(id, name, email, password)
        {
            Wallet = new Wallet();
        }
    }
}

