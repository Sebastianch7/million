using Domain.Entities;
using Application.Interfaces.Repositories;
using Infrastructure.Persistence;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class PropertyTraceRepository : IPropertyTraceRepository
    {
        private readonly IMongoCollection<PropertyTrace> _collection;

        public PropertyTraceRepository(MongoContext context)
        {
            _collection = context.PropertyTraces;
        }

        public async Task<List<PropertyTrace>> GetAllAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<PropertyTrace?> GetByIdAsync(string id) =>
            await _collection.Find(x => x.IdPropertyTrace == id).FirstOrDefaultAsync();
    }
}
