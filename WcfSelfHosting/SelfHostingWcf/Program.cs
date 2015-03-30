using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using TestWcfServiceLibrary;

namespace SelfHostingWcf
{
    // ReSharper disable once ClassNeverInstantiated.Global
    class Program
    {
        static void Main()
        {
            var baseAddress = new Uri("http://localhost:8080/hello");
            using (var host = new ServiceHost(typeof(Service1), baseAddress))
            {
                // Enable metadata publishing.
                var smb = new ServiceMetadataBehavior
                {
                    HttpGetEnabled = true,
                    MetadataExporter = {PolicyVersion = PolicyVersion.Policy15}
                };
                host.Description.Behaviors.Add(smb);

                // Open the ServiceHost to start listening for messages. Since
                // no endpoints are explicitly configured, the runtime will create
                // one endpoint per base address for each service contract implemented
                // by the service.
                host.Open();

                Console.WriteLine("The service is ready at {0}", baseAddress);
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();

                // Close the ServiceHost.
                host.Close();
            }
        }
    }
}
