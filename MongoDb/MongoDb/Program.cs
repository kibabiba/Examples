using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDb
{
    class Program
    {
        static void Main()
        {
            var client = new MongoClient("mongodb://127.0.0.1:27017");
            var database = client.GetDatabase("foo");
            var collection = database.GetCollection<BsonDocument>("bar");


            var document = new BsonDocument
            {
                { "name", "TryFind" },
                { "type", "Database" },
                { "count", 3 },
                { "info", new BsonDocument
                    {
                        { "x", 205 },
                        { "y", 102 }
                    }}
            };

            collection.InsertOne(document);


            var filter = Builders<BsonDocument>.Filter.Eq("name", "TryFind");
            collection.Find(filter).ToList().ForEach(Console.WriteLine);

            Console.ReadKey();
        }
    }
}
