using Grpc.Net.Client;
using Lctech.Configuration.Protobufs.Configuration;
using Mapster;
using EntitiesConfiguration = Lctech.Configuration.Domain.Entities.Configuration;
using ProtobufsConfiguration = Lctech.Configuration.Protobufs.Configuration.Configuration;

using var channel = GrpcChannel.ForAddress("http://localhost:8080");
var client = new ConfigurationService.ConfigurationServiceClient(channel);

//查詢

// var reply = await client.GetConfigurationsAsync(
//     new GetConfigurationRequest() { Group = "emoji", Level = 2});
//
// var config = new TypeAdapterConfig();
//
// config.NewConfig<ProtobufsConfiguration, EntitiesConfiguration>()
//     .Map(dest => dest.CreationDate, src => src.CreationDate.ToDateTimeOffset())
//     .Map(dest => dest.ModificationDate, src => src.ModificationDate.ToDateTimeOffset())
//     .Compile();

// var configurations = reply.Configurations.Adapt<List<EntitiesConfiguration>>(config);

//新增

// var insertConfigurations = new List<InsertConfiguration>();
// insertConfigurations.Add(new InsertConfiguration()
// {
//     Group = "testGroup",
//     Source = "testSource",
//     Value = "testValue_3",
//     ParentId = 180820643338518528
// });
// insertConfigurations.Add(new InsertConfiguration()
// {
//     Group = "testGroup",
//     Source = "testSource",
//     Value = "testValue_4",
//     ParentId = 180820643338518528
// });
//
// var reply = await client.InsertConfigurationsAsync(
//     new InsertConfigurationRequest() { Configurations = { insertConfigurations }});

//修改
var updateConfigurations = new List<UpdateConfiguration>();
updateConfigurations.Add(new UpdateConfiguration()
{
    Id = 180848843905040384,
    Value = "testValue_4_update",
    SortingIndex = 4,
    ModifierId = 4,
});
updateConfigurations.Add(new UpdateConfiguration()
{
    Key = "test_5",
    Value = "testValue_5_update",
    SortingIndex = 5,
    ModifierId = 5,
});

var reply = await client.UpdateConfigurationsAsync(
    new UpdateConfigurationRequest() { Configurations = { updateConfigurations }});


Console.WriteLine("Greeting: " );
Console.WriteLine("Press any key to exit...");
Console.ReadKey();
