using System;
using MongoDB.Bson;
using MongoDB.Driver;

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

        public long UpdateContact(Contact contact)
        {
            log("Updating document with id " + contact.id);

            if (contact.id == null || contact.id == ObjectId.Empty)
            {
                throw new Exception("Id cannot be null");
            }

            var filter = Builders<Contact>.Filter.Eq("id", contact.id);
            var update = Builders<Contact>.Update.
            Set(c => c.surname, contact.surname);

            var updateResult = mongoCollection.UpdateOne(filter, update);
            
            log("update OK: "+ updateResult.ModifiedCount + " documents modified");
            
            return updateResult.ModifiedCount;
     }

        private void log(String message)
        {
            Console.WriteLine(message);
        }
    }
}