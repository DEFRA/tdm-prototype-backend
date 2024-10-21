using HotChocolate.Data;
using MongoDB.Driver;
using System;
using HotChocolate;
using HotChocolate.Types;
using TdmPrototypeBackend.Types;
using TdmPrototypeBackend.Types.Extensions;
using TdmPrototypeBackend.Types.Ipaffs;

namespace GraphQL_play.Types
{
	[QueryType]
	public class Query
	{
		//[UsePaging]
		//[UseProjection]
		[UseSorting]
		[UseFiltering]
		public IExecutable<Notification> GetNotifications(IMongoCollection<Notification> collection)
		{
			return collection.AsExecutable();
		}

		[UseFirstOrDefault]
		public IExecutable<Notification> GetNotificationById(IMongoCollection<Notification> collection, string id)
		{
			return collection.Find(x => x.Id == id).AsExecutable();
		}
	}

	

	public class NotificationTypeExtensions : ObjectTypeExtension<Notification>
	{
		protected override void Configure(IObjectTypeDescriptor<Notification> descriptor)
		{
            //descriptor.BindFieldsExplicitly();
            descriptor.Field(f => f.Id);
            descriptor.Field(f => f._PointOfEntry).Ignore();
            descriptor.Field(f => f._MatchReference).Ignore();
            descriptor.Field(f => f._PointOfEntryControlPoint).Ignore();
            descriptor.Field(f => f._Ts).Ignore();

            descriptor.Field(f => f.Relationships).Ignore();
            descriptor.Field("Movements").Resolve((r, c) =>
                        {
                            //r.b
                            var notification = r.Parent<Notification>();
                            var i = MatchingReferenceNumber.FromIpaffs(notification.Id, notification.IpaffsType.Value);
                            var collection = r.Services.GetService<IMongoCollection<Movement>>();
                            return collection.AsQueryable().Where(x => x._MatchReferences.Contains(i.Identifier)).ToList();
                            return new List<Movement>();
                        }); //.Type<List<Movement>>();

        }
	}

    public class MovementTypeExtensions : ObjectTypeExtension<Movement>
    {
        protected override void Configure(IObjectTypeDescriptor<Movement> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Field(f => f._Ts).Ignore();
            descriptor.Field(f => f.Relationships).Ignore();
        }
    }

    //public class PersonBatchDataLoader : BatchDataLoader<string, List<Movement>>
    //{
    //	private readonly IMongoCollection<Movement> _repository;

    //	public PersonBatchDataLoader(
    //		IMongoCollection<Movement> repository,
    //		IBatchScheduler batchScheduler,
    //		DataLoaderOptions? options = null)
    //		: base(batchScheduler, options)
    //	{
    //		_repository = repository;
    //	}

    //	protected override async Task<IReadOnlyDictionary<string, List<Movement>>> LoadBatchAsync(
    //		IReadOnlyList<string> keys,
    //		CancellationToken cancellationToken)
    //	{
    //		// instead of fetching one person, we fetch multiple persons
    //		var persons = _repository.AsQueryable().Where(x => x._MatchReferences.Contains(keys));
    //		return persons.ToDictionary(x => x.Id);
    //	}
    //}
}
