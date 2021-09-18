using System;
using System.Collections.Generic;
using System.Text;

namespace OxygenDispersalSystem
{
    interface IConsumerRepo
    {
        void RegisterConsumer(string consumerId, ConsumerType consumerType, string city, string state, int maxRequired);
        void BookOxygen(string consumerId, int quantity);
    }
}
