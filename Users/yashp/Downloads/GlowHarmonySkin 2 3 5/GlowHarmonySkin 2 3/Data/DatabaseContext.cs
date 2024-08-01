using MongoDB.Driver;
using GlowHarmonySkin.Models;

namespace GlowHarmonySkin.Data
{
    public class DatabaseContext
    {
        private readonly IMongoDatabase _database;

        public DatabaseContext(IMongoClient client, string databaseName)
        {
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
        public IMongoCollection<Product> Products => _database.GetCollection<Product>("Products");
        public IMongoCollection<Order> Orders => _database.GetCollection<Order>("Orders");
        public IMongoCollection<Cart> Carts => _database.GetCollection<Cart>("Carts");
    }
}
