using Domain.Entities;
using Application.Interfaces.Repositories;
using Infrastructure.Persistence;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly IMongoCollection<Property> _collection;
        private readonly IMongoCollection<Owner> _owners;
        private readonly IMongoCollection<PropertyImage> _images;
        private readonly IMongoCollection<PropertyTrace> _traces;

        public PropertyRepository(MongoContext context)
        {
            _collection = context.Properties;
            _owners = context.Owners;
            _images = context.PropertyImages;
            _traces = context.PropertyTraces;
        }

        public async Task<List<Property>> GetAllAsync()
        {
            var properties = await _collection.Find(_ => true).ToListAsync();

            // 🔗 Manual join con Owner, Images y Traces
            foreach (var prop in properties)
            {
                prop.Owner = await _owners.Find(o => o.IdOwner == prop.IdOwner).FirstOrDefaultAsync();
                prop.Images = await _images.Find(img => img.IdProperty == prop.IdProperty).ToListAsync();
                prop.Traces = await _traces.Find(t => t.IdProperty == prop.IdProperty).ToListAsync();
            }

            return properties;
        }

        public async Task<Property?> GetByIdAsync(string id)
        {
            var property = await _collection.Find(x => x.IdProperty == id).FirstOrDefaultAsync();

            if (property == null)
                return null;

            property.Owner = await _owners.Find(o => o.IdOwner == property.IdOwner).FirstOrDefaultAsync();
            property.Images = await _images.Find(img => img.IdProperty == property.IdProperty).ToListAsync();
            property.Traces = await _traces.Find(t => t.IdProperty == property.IdProperty).ToListAsync();

            return property;
        }

        public async Task<List<Property>> GetFilteredAsync(
            string? name,
            string? address,
            decimal? minPrice,
            decimal? maxPrice)
        {
            var filterBuilder = Builders<Property>.Filter;
            var filter = filterBuilder.Empty;

            if (!string.IsNullOrEmpty(name))
                filter &= filterBuilder.Regex(p => p.Name, new MongoDB.Bson.BsonRegularExpression(name, "i"));

            if (!string.IsNullOrEmpty(address))
                filter &= filterBuilder.Regex(p => p.Address, new MongoDB.Bson.BsonRegularExpression(address, "i"));

            if (minPrice.HasValue)
                filter &= filterBuilder.Gte(p => p.Price, minPrice.Value);

            if (maxPrice.HasValue)
                filter &= filterBuilder.Lte(p => p.Price, maxPrice.Value);

            var properties = await _collection.Find(filter).ToListAsync();

            // 🔗 Igual que arriba: unir manualmente
            foreach (var prop in properties)
            {
                prop.Owner = await _owners.Find(o => o.IdOwner == prop.IdOwner).FirstOrDefaultAsync();
                prop.Images = await _images.Find(img => img.IdProperty == prop.IdProperty).ToListAsync();
                prop.Traces = await _traces.Find(t => t.IdProperty == prop.IdProperty).ToListAsync();
            }

            return properties;
        }
    }
}
