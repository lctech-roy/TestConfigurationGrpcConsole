using Grpc.Net.Client;
using Lctech.Configuration.Protobufs.HelloWorld;

using var channel = GrpcChannel.ForAddress("http://localhost:8080");
var client = new HelloWorldService.HelloWorldServiceClient(channel);
var reply = await client.GetWorldAsync(
    new GetWorldRequest() { World = "Hello" });
Console.WriteLine("Greeting: " + reply.World);
Console.WriteLine("Press any key to exit...");
Console.ReadKey();
