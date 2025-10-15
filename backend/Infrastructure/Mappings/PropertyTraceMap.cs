using Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Infrastructure.Mappings
{
    public static class PropertyTraceMap
    {
        public static void Configure()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(PropertyTrace)))
            {
                BsonClassMap.RegisterClassMap<PropertyTrace>(cm =>
                {
                    cm.AutoMap();
                    cm.SetIgnoreExtraElements(true);

                    cm.MapIdMember(c => c.Id)
                      .SetSerializer(new StringSerializer(BsonType.ObjectId));

                    cm.MapMember(c => c.IdPropertyTrace).SetElementName("IdPropertyTrace");
                    cm.MapMember(c => c.DateSale).SetElementName("DateSale");
                    cm.MapMember(c => c.Name).SetElementName("Name");
                    cm.MapMember(c => c.Value).SetElementName("Value");
                    cm.MapMember(c => c.Tax).SetElementName("Tax");
                    cm.MapMember(c => c.IdProperty).SetElementName("IdProperty");
                });
            }
        }
    }
}
