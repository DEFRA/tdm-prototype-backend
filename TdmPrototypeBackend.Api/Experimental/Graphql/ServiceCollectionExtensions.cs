using GraphQL_play.Types;
using HotChocolate.Execution.Configuration;
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
                
                .AddTdmTypes()
                .ModifyOptions(o =>
                {
                    o.StrictValidation = false;
                })
                .AddType<Query>()
                .AddMongoDbFiltering()
                .AddMongoDbSorting();
            //.AddTypeExtension<MovementTypeExtensions>();



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

        public static IRequestExecutorBuilder AddTdmTypes(this IRequestExecutorBuilder builder)
        {
            builder.AddTypeExtension<global::GraphQL_play.Types.Query>();
            //builder.AddType<global::GraphQL_play.Types.NotificationType>();
            builder.AddTypeExtension<global::GraphQL_play.Types.NotificationTypeExtensions>();
            builder.AddTypeExtension<global::GraphQL_play.Types.MovementTypeExtensions>();
            builder.ConfigureSchema(
                b => b.TryAddRootType(
                    () => new global::HotChocolate.Types.ObjectType(
                        d => d.Name(global::HotChocolate.Types.OperationTypeNames.Query)),
                    HotChocolate.Language.OperationType.Query));
            return builder;
        }
    }
}
