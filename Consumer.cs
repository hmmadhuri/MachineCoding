using System;
using System.Collections.Generic;
using System.Text;

namespace OxygenDispersalSystem
{
    class Consumer
    {
        public string ConsumerID { get; set; }
        public ConsumerType CustomerType { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int MaximumRequirement { get; set; }
        public int AvailableOxygen { get; set; }
    }

    public enum ConsumerType
    {
        Hospitals,
        Industry
    }
}
