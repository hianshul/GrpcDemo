using Grpc.Net.Client;
using System;
using GrpcServer;
using System.Threading.Tasks;
using System.Net.Http;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //var httpClientHandler = new HttpClientHandler();
            //// Return `true` to allow certificates that are untrusted/invalid
            //httpClientHandler.ServerCertificateCustomValidationCallback =
            //    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            //var httpClient = new HttpClient(httpClientHandler);

            var channel = GrpcChannel.ForAddress("https://localhost:50051");
            var client = new Greeter.GreeterClient(channel);
            
            var response = await client.SayHelloAsync(new HelloRequest
            { 
                Name="Anshul"
            });
            Console.WriteLine(response.Message);
            Console.WriteLine("Hello World!");
        }
    }
}
