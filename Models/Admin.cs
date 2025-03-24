using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideSharingSystem.Models
{
    public class Admin : User
    {
        // Constructor
        public Admin(int id, string name, string email, string password)
            : base(id, name, email, password)
        {
        }
    }
}
