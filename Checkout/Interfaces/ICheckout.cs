using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Interfaces
{
    internal interface ICheckout
    {
        void Scan(string item);
        int GetTotalPrice();
    }
}
