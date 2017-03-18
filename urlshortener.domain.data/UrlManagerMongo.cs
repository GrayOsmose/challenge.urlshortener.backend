using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using urlshortener.domain.model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace urlshortener.domain.data
{
    public class UrlManagerMongo : IUrlManager
    {
        private const string MongoClientConnectionString = "urlshortener_mongo";
        private const string CollectionName = "urls";
        
        private readonly IMongoDatabase _database;

        public UrlManagerMongo()
        {
            var client   = new MongoClient(MongoClientConnectionString);
            _database = client.GetDatabase(CollectionName);
        }

        public async Task AddCounter(string key)
        {
            var collection = GetCollection();

            await collection.UpdateOneAsync(Builders<UrlModel>.Filter.Eq(x => x.Key, key),
                                            Builders<UrlModel>.Update.Inc(x => x.ClickCount, 1));
        }

        public async Task AddUrl(UrlModel urlModel)
        {
            var collection = GetCollection();

            await collection.InsertOneAsync(urlModel);
        }

        public async Task<UrlModel> GetUrlModel(string key)
        {
            var collection = GetCollection();
            
            return await collection.Find(Builders<UrlModel>.Filter.Eq(x => x.Key, key))
                                   .FirstOrDefaultAsync();
        }

        public async Task<List<UrlModel>> GetUrlModels(Guid userGuid)
        {
            var collection = GetCollection();

            return await collection.Find(Builders<UrlModel>.Filter.Eq(x => x.UserGuid, userGuid))
                                   .ToListAsync();
        }

        private IMongoCollection<UrlModel> GetCollection()
        {
            return _database.GetCollection<UrlModel>(CollectionName);
        }
    }
}
