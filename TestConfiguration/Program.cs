using Grpc.Net.Client;
using Lctech.Configuration.Protobufs.Configuration;
using Mapster;
using EntitiesConfiguration = Lctech.Configuration.Domain.Entities.Configuration;
using ProtobufsConfiguration = Lctech.Configuration.Protobufs.Configuration.QueryConfigurationResult.Types.Configuration;

using var channel = GrpcChannel.ForAddress("http://localhost:8080");
var client = new ConfigurationService.ConfigurationServiceClient(channel);

//查詢
 var reply = await client.QueryConfigurationsAsync(
     new QueryConfigurationRequest() { Group = "forumFaq", Level = 2});

 var config = new TypeAdapterConfig();

 config.NewConfig<ProtobufsConfiguration, EntitiesConfiguration>()
     .Map(dest => dest.CreationDate, src => src.CreationDate.ToDateTimeOffset())
     .Map(dest => dest.ModificationDate, src => src.ModificationDate.ToDateTimeOffset())
     .Compile();

 var configurations = reply.Content.Adapt<List<EntitiesConfiguration>>(config);

//新增

// var insertConfigurations = new List<InsertConfiguration>();
// insertConfigurations.Add(new InsertConfiguration()
// {
//     Group = "testGroup",
//     Source = "testSource",
//     Value = "testValue_3",
//     Key = "testGroup1"
//     // ParentId = 180820643338518528
// });
// insertConfigurations.Add(new InsertConfiguration()
// {
//     Group = "testGroup",
//     Source = "testSource",
//     Value = "testValue_4",
//     Key = "testGroup2"
//     // ParentId = 180820643338518528
// });
//
// var reply = await client.InsertConfigurationsAsync(
//     new InsertConfigurationRequest() { Configurations = { insertConfigurations }});

//修改
  // var updateConfigurations = new List<UpdateConfiguration>();
  // updateConfigurations.Add(new UpdateConfiguration()
  // {
  //     Id = 183417611147542528,
  //     Value = "testValue_4_updatess",
  //     SortingIndex = 123,
  //     ModifierId = 122,
  // });
  // updateConfigurations.Add(new UpdateConfiguration()
  // {
  //     Key = "testGroup2",
  //     Value = "testValue_5_updatess",
  //     SortingIndex = 123,
  //     ModifierId = 122,
  // });

  // var reply = await client.UpdateConfigurationsAsync(
  //     new UpdateConfigurationRequest() { Configurations = { updateConfigurations }});


//刪除
// var deleteConfigurations = new List<DeleteConfiguration>();
// deleteConfigurations.Add(new DeleteConfiguration()
// {
//     Key = "emoji_6",
//     IncludeChildren = true
// });
// deleteConfigurations.Add(new DeleteConfiguration()
// {
//     Key = "testGroup2",
// });

// var reply = await client.DeleteConfigurationsAsync(
//     new DeleteConfigurationRequest() { Configurations = { deleteConfigurations }});

Console.WriteLine("Greeting: " );
Console.WriteLine("Press any key to exit...");
Console.ReadKey();
