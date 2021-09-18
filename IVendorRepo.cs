using System;
using System.Collections.Generic;
using System.Text;

namespace OxygenDispersalSystem
{
    interface IVendorRepo
    {
        void RegisterVendor(string city, string state, int medOxygen, int indOxygen);
        
    }
}
