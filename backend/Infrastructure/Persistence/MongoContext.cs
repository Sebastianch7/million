using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Domain.Entities;

namespace Infrastructure.Persistence
{
    public class MongoContext
    {
        private readonly IMongoDatabase _db;

        public MongoContext(IConfiguration configuration)
        {
            var connectionString = configuration["MongoSettings:ConnectionString"] ?? "mongodb://localhost:27017";
            var databaseName = configuration["MongoSettings:DatabaseName"] ?? "millionDB";

            var client = new MongoClient(connectionString);
            _db = client.GetDatabase(databaseName);
        }

        public IMongoCollection<Owner> Owners => _db.GetCollection<Owner>("Owners");
        public IMongoCollection<Property> Properties => _db.GetCollection<Property>("Properties");
        public IMongoCollection<PropertyImage> PropertyImages => _db.GetCollection<PropertyImage>("PropertyImages");
        public IMongoCollection<PropertyTrace> PropertyTraces => _db.GetCollection<PropertyTrace>("PropertyTraces");
    }
}
