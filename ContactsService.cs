using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace mongoContacts
{
    public class ContactsService
    {
        private const string db = "learning";
        private const string collection = "contacts";
        private MongoClient mongoClient;
        private IMongoDatabase mongoDatabase;
        private IMongoCollection<Contact> mongoCollection;

        public ContactsService(string mongoServerIP)
        {
            this.mongoClient = new MongoClient("mongodb://" + mongoServerIP);
            this.mongoDatabase = mongoClient.GetDatabase(db);
            this.mongoCollection = mongoDatabase.GetCollection<Contact>(collection);
        }

        public void Insert(Contact contact)
        {
            mongoCollection.InsertOne(contact);
        }

        public void Find(Contact contact)
        {
            var contacts = mongoCollection.Find(x => x.name == contact.name).ToList();
        }

        public bool Exist(Contact contact)
        {
            var filter = Builders<Contact>.Filter.Eq(x => x.name, contact.name);
            var filter2 = Builders<Contact>.Filter.And(
            Builders<Contact>.Filter.Eq("name", contact.name),
            Builders<Contact>.Filter.Eq("surname", contact.surname)
            );
            FilterDefinition<Contact> filter4 = new BsonDocument().Add("name", contact.name)
            .Add("surname", contact.surname);

            var count = mongoCollection.CountDocuments(filter4);
            var count2 = mongoCollection.CountDocuments(filter2);
            var count3 = mongoCollection.CountDocuments(x => x.name == contact.name);


            return count > 0;
        }
    }
}