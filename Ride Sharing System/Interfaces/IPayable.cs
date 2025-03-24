using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideSharingSystem.Interfaces
{
    public interface IPayable
    {
        void AddFunds(int userId, decimal amount);
        bool DeductFunds(int userId, decimal amount);
    }
}

