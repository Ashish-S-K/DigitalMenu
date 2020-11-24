using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MenuAPI
{
    public class MongoDbHelper
    {
        private IMongoDatabase db;

        public MongoDbHelper(string database)
        {
            var client = new MongoClient();
            db = client.GetDatabase(database);
        }

        public void InsertDocument<T>(string collectionName, T document)
        {
            var collection = db.GetCollection<T>(collectionName);
            collection.InsertOne(document);
        }

        public List<T> ReadDocument<T>(string collectionName)
        {
            var collection = db.GetCollection<T>(collectionName);
            return collection.Find(new BsonDocument()).ToList();
        }

        public T ReadDocumentById<T>(string collectionName, string id)
        {
            try
            {
                var collection = db.GetCollection<T>(collectionName);
                var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
                var result = collection.Find(filter).First();                
                return result;
            }
            catch (Exception)
            {                
                return default(T);               
            }            
        }
    }
}