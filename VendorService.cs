using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OxygenDispersalSystem
{
    class VendorService : IVendorRepo
    {
        public List<Vendor> vendors; 
        public VendorService()
        {
            vendors = new List<Vendor>();
        }
        public void RegisterVendor(string city, string state, int medOxygen, int indOxygen)
        {
            if (vendors.Where(val => val.City == city).Any())
            {
                Console.WriteLine("Vendor already exists for the city");
            }
            else
            {
                vendors.Add(new Vendor
                {
                    City = city,
                    State = state,
                    MedicalOxygenCapacity = medOxygen,
                    IndustrialOxygenCapacity = indOxygen
                });
            }
        }
    }
}
