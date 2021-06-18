using Microsoft.Extensions.Options;
using Mongo.Database.Interfaces;
using Mongo.Database.Models;
using Mongo.Settings;
using MongoDB.Driver;

namespace Mongo.Database
{
    public class BookstoreContext : IBookstoreContext
    {
        private readonly IMongoCollection<Book> _books;

        public BookstoreContext(IOptions<ApplicationSettings> bookstoreDbConfig)
        {
            var client = new MongoClient(bookstoreDbConfig.Value.AppSettings.ConnectionString);
            var database = client.GetDatabase(bookstoreDbConfig.Value.AppSettings.DatabaseName);
            _books = database.GetCollection<Book>(bookstoreDbConfig.Value.AppSettings.CollectionName);
        }

        public IMongoCollection<Book> GetBooksCollection() => _books;
    }
}
