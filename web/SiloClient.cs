using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Configuration;

namespace web
{
    public class SiloClient
    {
        private static IClusterClient client;

        public static IClusterClient Instance
        {
            get
            {
                return client;
            }
        }

        public static async Task ConnectClient()
        {
            client = new ClientBuilder()
                .UseLocalhostClustering()
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "test-cluster";
                    options.ServiceId = "test-service";
                })
                .ConfigureLogging(logging => logging.AddConsole())
                .Build();

            await client.Connect();
            Console.WriteLine("Client successfully connected to silo host \n");
        }
    }
}