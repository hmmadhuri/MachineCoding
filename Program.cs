using System;

namespace OxygenDispersalSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            VendorService vendorService = new VendorService();
            ConsumerService consumerService = new ConsumerService(vendorService);

            vendorService.RegisterVendor("Bengaluru", "Karnataka", 100, 100);
            vendorService.RegisterVendor("Mysuru", "Karnataka", 50, 100);

            consumerService.RegisterConsumer("H1", ConsumerType.Hospitals, "Bengaluru", "Karnataka", 150);
            consumerService.RegisterConsumer("H2", ConsumerType.Hospitals, "Bengaluru", "Karnataka", 150);

            consumerService.RegisterConsumer("I1", ConsumerType.Industry, "Bengaluru", "Karnataka", 150);

            consumerService.BookOxygen("H1", 120);
            consumerService.BookOxygen("I1", 100);

            consumerService.ShowAllVendors("Karnataka");
            consumerService.ShowAllHospitals("Bengaluru");

            consumerService.ShowAllIndustries();


        }
    }
}
