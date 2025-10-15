using Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Infrastructure.Mappings
{
    public static class PropertyMap
    {
        public static void Configure()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Property)))
            {
                BsonClassMap.RegisterClassMap<Property>(cm =>
                {
                    cm.AutoMap();
                    cm.SetIgnoreExtraElements(true);

                    cm.MapIdMember(c => c.Id)
                      .SetSerializer(new StringSerializer(BsonType.ObjectId));

                    cm.MapMember(c => c.IdProperty).SetElementName("IdProperty");
                    cm.MapMember(c => c.Name).SetElementName("Name");
                    cm.MapMember(c => c.Address).SetElementName("Address");
                    cm.MapMember(c => c.Price).SetElementName("Price");
                    cm.MapMember(c => c.CodeInternal).SetElementName("CodeInternal");
                    cm.MapMember(c => c.Year).SetElementName("Year");
                    cm.MapMember(c => c.IdOwner).SetElementName("IdOwner");
                });
            }
        }
    }
}
