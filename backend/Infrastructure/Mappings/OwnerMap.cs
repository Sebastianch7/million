using Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Infrastructure.Mappings
{
    public static class OwnerMap
    {
        public static void Configure()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Owner)))
            {
                BsonClassMap.RegisterClassMap<Owner>(cm =>
                {
                    cm.AutoMap();
                    cm.SetIgnoreExtraElements(true);

                    cm.MapIdMember(c => c.Id)
                      .SetSerializer(new StringSerializer(BsonType.ObjectId));

                    cm.MapMember(c => c.IdOwner).SetElementName("IdOwner");
                    cm.MapMember(c => c.Name).SetElementName("Name");
                    cm.MapMember(c => c.Address).SetElementName("Address");
                    cm.MapMember(c => c.Photo).SetElementName("Photo");
                    cm.MapMember(c => c.Birthday).SetElementName("Birthday");
                });
            }
        }
    }
}
