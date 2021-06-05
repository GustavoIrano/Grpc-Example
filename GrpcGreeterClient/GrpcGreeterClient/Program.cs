using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrpcGreeterClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // The port number(5001) must match the port of the gRPC server.
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);

            var reply = await client.SayHelloAsync(
                              new HelloRequest { Name = "GreeterClient" });

            Console.WriteLine("Hello Greeting: " + reply.Message);

            Console.WriteLine();

            var g = await client.ReturnGuidAsync(
                              new HelloRequest { Name = "GreeterClient" });

            Console.WriteLine("Guid: " + g.Guid);

            Console.WriteLine();

            var listaNumerosMega = "";

            for (int i = 1; i < 7; i++)
            {
                var n = await client.ReturnNumberRangeMegaSenaAsync(
                              new HelloRequest { Name = "GreeterClient" });

                listaNumerosMega += n.Message + ", ";
            }

            Console.WriteLine("Sorted Numbers: " + listaNumerosMega.Substring(0, listaNumerosMega.Length - 2));

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
