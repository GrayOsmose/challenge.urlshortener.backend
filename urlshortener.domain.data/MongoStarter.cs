using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace urlshortener.domain.data
{
    internal static class MongoStarter
    {
        public static IMongoCollection<T> GetCollection<T>(string connectionString, string collectionName)
        {
            var client = new MongoClient(connectionString);
            var _database = client.GetDatabase(collectionName);

            return _database.GetCollection<T>(collectionName);
        }
    }
}
