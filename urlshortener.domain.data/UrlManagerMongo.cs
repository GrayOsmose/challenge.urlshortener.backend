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
        private readonly IMongoCollection<UrlModel> _collection;

        public UrlManagerMongo(string connectionString)
        {
            _collection = MongoStarter.GetCollection<UrlModel>(connectionString, "urls");

            IndexesCreation(_collection);
        }

        private static void IndexesCreation(IMongoCollection<UrlModel> collection)
        {
            // key search and uniqueness
            collection.Indexes.CreateOne(Builders<UrlModel>.IndexKeys.Ascending(x => x.Key),
                                         new CreateIndexOptions { Unique = true });
            // user guid search
            collection.Indexes.CreateOne(Builders<UrlModel>.IndexKeys.Ascending(x => x.UserGuid));
        }

        public async Task AddCounter(string key)
        {
            await _collection.UpdateOneAsync(Builders<UrlModel>.Filter.Eq(x => x.Key, key),
                                             Builders<UrlModel>.Update.Inc(x => x.ClickCount, 1));
        }

        public async Task AddUrl(UrlModel urlModel)
        {
            await _collection.InsertOneAsync(urlModel);
        }

        public async Task DeleteUrl(string key)
        {
            await _collection.DeleteOneAsync(Builders<UrlModel>.Filter.Eq(x => x.Key, key));
        }

        public async Task<UrlModel> GetUrlModel(string key)
        {            
            return await _collection.Find(Builders<UrlModel>.Filter.Eq(x => x.Key, key))
                                    .FirstOrDefaultAsync();
        }

        public async Task<List<UrlModel>> GetUrlModels(Guid userGuid)
        {
            return await _collection.Find(Builders<UrlModel>.Filter.Eq(x => x.UserGuid, userGuid))
                                    .ToListAsync();
        }
    }
}
