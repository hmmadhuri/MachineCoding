using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OxygenDispersalSystem
{
    class ConsumerService: IConsumerRepo
    {
        List<Consumer> consumers;
        List<Vendor> vendor;
        public ConsumerService(VendorService vendor)
        {
            this.vendor = vendor.vendors;
            consumers = new List<Consumer>();
        }

        public void BookOxygen(string consumerId, int quantity)
        {
            var assignedVendor = new Vendor();
            if (consumerId.Contains("H"))
            {
                var vendors = vendor.OrderByDescending(val => val.MedicalOxygenCapacity).ToList();
                if (vendors.First().MedicalOxygenCapacity < quantity)
                {
                    vendors= vendor.OrderByDescending(val => val.MedicalOxygenCapacity+val.IndustrialOxygenCapacity).ToList();
                    assignedVendor = vendors.First();
                    
                    vendors.First().IndustrialOxygenCapacity -= quantity - vendors.First().MedicalOxygenCapacity;
                    vendors.First().MedicalOxygenCapacity = 0;


                    
                }
                else
                {
                    assignedVendor = vendors.First();
                    vendors.First().MedicalOxygenCapacity -= quantity;
                }

                
            }

            if (consumerId.Contains("I"))
            {
                var vendors = vendor.OrderByDescending(val => val.IndustrialOxygenCapacity).ToList();
                if (vendors.First().IndustrialOxygenCapacity < quantity)
                {
                    Console.WriteLine("Order Cannot be placed.");
                }
                else
                {
                    assignedVendor = vendors.First();
                    vendors.First().IndustrialOxygenCapacity -= quantity;
                }

               
            }
            var remainingRequest = consumers.Where(val => val.ConsumerID == consumerId).Select(val => val.MaximumRequirement).First() - quantity;
            Console.WriteLine($"Medical Oxygen booked from {assignedVendor.City}. {consumerId} can book more {remainingRequest}L of oxygen");
            consumers.Where(val => val.ConsumerID == consumerId).First().AvailableOxygen = quantity;
        }

        public void RegisterConsumer(string consumerId, ConsumerType consumerType, string city, string state, int maxRequired)
        {
            consumers.Add(new Consumer
            {
                ConsumerID=consumerId,
                CustomerType=consumerType,
                City=city,
                State=state,
                MaximumRequirement=maxRequired
            });
            
        }

        public void ShowAllVendors(string state)
        {
            var vendors = vendor.Where(val => val.State == state).OrderByDescending(val=>val.IndustrialOxygenCapacity+val.MedicalOxygenCapacity).ToList();
            foreach(var vendor in vendors)
            {
                Console.WriteLine($"{vendor.City}, {vendor.MedicalOxygenCapacity}, {vendor.IndustrialOxygenCapacity}");
            }
        }

        public void ShowAllHospitals(string city)
        {
            var con = consumers.Where(val => val.City == city && val.CustomerType == ConsumerType.Hospitals).OrderByDescending(val => val.AvailableOxygen).ToList();
            foreach(var consumer in con)
            {
                Console.WriteLine($"{consumer.ConsumerID}, {consumer.City}, {consumer.State}, {consumer.AvailableOxygen}");
            }
        }

        public void ShowAllIndustries()
        {
            var industries = consumers.Where(val => val.CustomerType == ConsumerType.Industry).OrderByDescending(val => val.MaximumRequirement - val.AvailableOxygen).ToList();
            foreach (var industry in industries)
            {
                Console.WriteLine($"{industry.ConsumerID}, {industry.City}, {industry.State}, {industry.MaximumRequirement - industry.AvailableOxygen}");
            }
        }
    }
}
