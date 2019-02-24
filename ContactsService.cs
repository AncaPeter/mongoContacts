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

        public void Insert(Contact contact){
            mongoCollection.InsertOne(contact);
        }
    }
}