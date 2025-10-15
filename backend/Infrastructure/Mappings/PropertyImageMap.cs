using Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Infrastructure.Mappings
{
    public static class PropertyImageMap
    {
        public static void Configure()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(PropertyImage)))
            {
                BsonClassMap.RegisterClassMap<PropertyImage>(cm =>
                {
                    cm.AutoMap();
                    cm.SetIgnoreExtraElements(true);

                    cm.MapIdMember(c => c.Id)
                      .SetSerializer(new StringSerializer(BsonType.ObjectId));

                    cm.MapMember(c => c.IdPropertyImage).SetElementName("IdPropertyImage");
                    cm.MapMember(c => c.IdProperty).SetElementName("IdProperty");
                    cm.MapMember(c => c.File).SetElementName("File");
                    cm.MapMember(c => c.Enabled).SetElementName("Enabled");
                });
            }
        }
    }
}
