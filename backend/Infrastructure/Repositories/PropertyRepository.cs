using Domain.Entities;
using Application.Interfaces.Repositories;
using Infrastructure.Persistence;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly IMongoCollection<Property> _collection;

        public PropertyRepository(MongoContext context)
        {
            _collection = context.Properties;
        }

        public async Task<IEnumerable<Property>> GetAllAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<Property?> GetByIdAsync(string id) =>
            await _collection.Find(x => x.IdProperty == id).FirstOrDefaultAsync();
    }
}
