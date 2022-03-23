using Grpc.Net.Client;
using Lctech.Configuration.Protobufs.Configuration;

using var channel = GrpcChannel.ForAddress("http://localhost:8080");
var client = new ConfigurationService.ConfigurationServiceClient(channel);
var reply = await client.GetConfigurationAsync(
    new GetConfigurationRequest() { World = "Hello" });
Console.WriteLine("Greeting: " + reply.World);
Console.WriteLine("Press any key to exit...");
Console.ReadKey();
