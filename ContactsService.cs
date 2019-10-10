using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

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

        public List<Contact> Find(Contact contact)
        {
            var contacts = mongoCollection.Find(x => x.name == contact.name).ToList();
            return contacts;
        }

        public bool Exists(Contact contact)
        {
            var filter = Builders<Contact>.Filter.And(
            Builders<Contact>.Filter.Eq("name", contact.name),
            Builders<Contact>.Filter.Eq("surname", contact.surname)
            );
            var count = mongoCollection.CountDocuments(filter);

            return count > 0;
        }
    }
}