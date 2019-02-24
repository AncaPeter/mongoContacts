using System;
using Newtonsoft.Json;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;

namespace mongoContacts
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
           /*var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("learning");
            var collection = database.GetCollection<BsonDocument>("contacts");*/
            ContactsService contactService = new ContactsService("localhost");
            Contact contact = new Contact();
            contact.name = "JS";
            contact.surname ="xyz";
            contact.email.Add("xxx");
            contactService.Find(contact);
            contactService.Insert(contact);
            contactService.Exist(contact);
        }
    }
}
