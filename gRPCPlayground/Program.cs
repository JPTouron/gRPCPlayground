using Grpc.Net.Client;
using GrpcService1;
using System;
using System.Threading.Tasks;

namespace gRPCPlayground
{
    internal class Program
    {
        private static async Task GreeterServiceInvoke(GrpcChannel channel)
        {
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
                              new HelloRequest { Name = "GreeterClient" });
            Console.WriteLine("Greeting: " + reply.Message);
        }

        private static async Task Main(string[] args)
        {
            // The port number(5001) must match the port of the gRPC server.
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            await GreeterServiceInvoke(channel);

            await PerformerServiceInvoke(channel);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static async Task PerformerServiceInvoke(GrpcChannel channel)
        {
            var clientPerformer = new Performer.PerformerClient(channel);
            var perfReply = await clientPerformer.PerformItAsync(
                                new PerformRequest { Name = "Harry" });

            Console.WriteLine($"Performer chosen: Name:'{perfReply.Name}', Age: '{perfReply.Age}'");
        }
    }
}