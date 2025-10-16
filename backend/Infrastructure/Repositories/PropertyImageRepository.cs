using Domain.Entities;
using Application.Interfaces.Repositories;
using Infrastructure.Persistence;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class PropertyImageRepository : IPropertyImageRepository
    {
        private readonly IMongoCollection<PropertyImage> _collection;

        public PropertyImageRepository(MongoContext context)
        {
            _collection = context.PropertyImages;
        }

        public async Task<List<PropertyImage>> GetAllAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<PropertyImage?> GetByIdAsync(string id) =>
            await _collection.Find(x => x.IdPropertyImage == id).FirstOrDefaultAsync();
    }
}
