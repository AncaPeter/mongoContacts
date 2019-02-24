using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace mongoContacts
{
    public class Contact
    {
        private List<string> _email = new List<string>();

        public ObjectId id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public List<string> email { get => _email; set => _email = value; }
        public int phone { get; set; }
        public DateTime birthdate { get; set; }
        public int age { get; set; }
    }
}