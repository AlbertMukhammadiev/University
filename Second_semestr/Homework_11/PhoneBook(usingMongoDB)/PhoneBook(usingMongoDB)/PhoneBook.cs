using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace PhoneBookNamespace
{
    /// <summary>
    /// class, that represents a telephone record
    /// </summary>
    [BsonIgnoreExtraElements]
    public class Record
    {
        public string Name { get; set; }
        public string Number { get; set; }
    }

    /// <summary>
    /// class Phone Book, that uses MongoDB
    /// </summary>
    public class PhoneBook : IPhoneBook
    {
        /// <summary>
        /// class constructor
        /// </summary>
        public PhoneBook()
        {
            client = new MongoClient();
            database = client.GetDatabase("PhoneBook");
            collection = database.GetCollection<Record>("records");
        }

        public void Add(Record newRecord)
        {
            var phoneBook = collection.Find(new BsonDocument()).ToList();
            foreach (var record in phoneBook)
            {
                if (record.Number == newRecord.Number)
                {
                    Console.WriteLine("this phone number already exists in database");
                    return;
                }
            }

            collection.InsertOne(newRecord);
        }

        public void FindByNumber(string number)
        {
            var phoneBook = collection.Find(new BsonDocument()).ToList();
            foreach (var record in phoneBook)
            {
                if (record.Number == number)
                {
                    Console.WriteLine("This person is " + record.Name);
                    return;
                }
            }

            Console.WriteLine("There is no man with a such telephone number in base");
        }

        public void FindByName(string name)
        {
            Console.WriteLine("Telephone numbers of persons with given name:");
            int quantity = 0;
            foreach (var record in collection.AsQueryable().Where(x => x.Name == name).ToList())
            {
                ++quantity;
                Console.WriteLine(" " + quantity + ") " + record.Number);
            }

            if (quantity == 0)
            {
                Console.WriteLine("There is no person with given name");
            }
        }

        public void Print()
        {
            var phoneBook = collection.Find(new BsonDocument()).ToList();
            foreach (var record in phoneBook)
            {
                Console.WriteLine(record.Name + " " + record.Number);
            }
        }

        private MongoClient client;
        private IMongoDatabase database;
        private IMongoCollection<Record> collection;
    }
}
