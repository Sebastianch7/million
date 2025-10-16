using Domain.Entities;
using Application.Interfaces.Repositories;
using Infrastructure.Persistence;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly IMongoCollection<Owner> _collection;

        public OwnerRepository(MongoContext context)
        {
            _collection = context.Owners;
        }

        public async Task<List<Owner>> GetAllAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<Owner?> GetByIdAsync(string id) =>
            await _collection.Find(x => x.IdOwner == id).FirstOrDefaultAsync();
    }
}
