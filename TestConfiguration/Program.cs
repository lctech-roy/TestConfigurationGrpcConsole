using Grpc.Net.Client;
using Lctech.Configuration.Protobufs.Configuration;
using Mapster;
using EntitiesConfiguration = Lctech.Configuration.Domain.Entities.Configuration;
using ProtobufsConfiguration = Lctech.Configuration.Protobufs.Configuration.Configuration;

using var channel = GrpcChannel.ForAddress("http://localhost:8080");
var client = new ConfigurationService.ConfigurationServiceClient(channel);
var reply = await client.GetConfigurationsByGroupAsync(
    new GetConfigurationRequest() { Group = "common", Level = 1});

var config = new TypeAdapterConfig();

config.NewConfig<ProtobufsConfiguration, EntitiesConfiguration>()
    .Map(dest => dest.CreationDate, src => src.CreationDate.ToDateTimeOffset())
    .Map(dest => dest.ModificationDate, src => src.ModificationDate.ToDateTimeOffset())
    .Compile();

var configurations = reply.Configurations.Adapt<List<EntitiesConfiguration>>(config);

Console.WriteLine("Greeting: " + reply.Configurations);
Console.WriteLine("Press any key to exit...");
Console.ReadKey();
