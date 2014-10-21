using System;
using System.ServiceModel;
using DuplexClient.DuplexWcf;

namespace DuplexClient
{
    // ReSharper disable once ClassNeverInstantiated.Global
    class Program
    {
        static void Main()
        {
            var client = new DuplexServiceClient(new InstanceContext(new Callback()));
            Console.WriteLine(client.LongProcess(123));
            Console.ReadKey();
        }

        private class Callback : IDuplexServiceCallback
        {
            public void ClientNotify(string value)
            {
                Console.WriteLine(value);
            }
        }
    }
}
