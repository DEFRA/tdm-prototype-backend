using GraphQL_play.Types;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using TdmPrototypeBackend.Storage.Mongo;
using TdmPrototypeBackend.Types;
using TdmPrototypeBackend.Types.Ipaffs;

namespace TdmPrototypeBackend.Api.Experimental.Graphql
{
    public static class ServiceCollectionExtensions
    {
        public static void AddExperimentalGraphQl(this IHostApplicationBuilder builder)
        {
            builder.AddGraphQL()
                .ModifyOptions(o =>
                    {
                        o.StrictValidation = false;
                    })
                .AddType<Query>()
                .AddMongoDbFiltering()
                .AddMongoDbSorting("MyScope")
                .AddTypeExtension<NotificationTypeExtensions>();
           

            builder.Services.AddSingleton(sp =>
            {
                var options = sp.GetService<MongoDbOptions<Notification>>();
                return sp.GetService<IMongoDbClientFactory>().GetCollection<Notification>(options.CollectionName);
            });

            builder.Services.AddSingleton(sp =>
            {
                var options = sp.GetService<MongoDbOptions<Movement>>();
                return sp.GetService<IMongoDbClientFactory>().GetCollection<Movement>(options.CollectionName);
            });
        }
    }
}
