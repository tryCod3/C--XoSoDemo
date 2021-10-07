using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoDe.database
{

    class ConnectDb
    {
        private static IMongoDatabase db;

        public ConnectDb()
        {

        }

        public static bool hasConnect()
        {
            return db == null ? false : true;
        }

        public static IMongoDatabase getInstance()
        {
            return db;
        }

        public static void connect()
        {
            var client = new MongoClient(ConfigDb.NAME_CONNECT);
            db = client.GetDatabase(ConfigDb.NAME_DB);
        }


        public static void insert<T>(T record)
        {
            var collection = db.GetCollection<T>(ConfigDb.COLLECTION);
            collection.InsertOne(record);
        }

        public void read()
        {
            var coll = db.GetCollection<BsonDocument>(ConfigDb.COLLECTION);
            var filter = Builders<BsonDocument>.Filter.Empty;
            var result = coll.Find(filter).ToList();
            foreach (var doc in result)
            {
                Console.WriteLine(doc);
            }
        }
   
        public static List<BsonDocument> getContent(string date, string local)
        {
            try
            {
                var collection = db.GetCollection<BsonDocument>(ConfigDb.COLLECTION);
                var build = Builders<BsonDocument>.Filter;
                var filler = build.Eq("date", date) & build.Eq("local", local);
                var docs = collection.Find(filler).ToList();
                return docs;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public static void update(string local , string localNew)
        {
            var collection = db.GetCollection<BsonDocument>(ConfigDb.COLLECTION);
            var build = Builders<BsonDocument>.Filter;
            var filler = build.Eq("local", local);
            var u = Builders<BsonDocument>.Update.Set("local", localNew);
            collection.UpdateMany(filler , u);
        }

    }
}

