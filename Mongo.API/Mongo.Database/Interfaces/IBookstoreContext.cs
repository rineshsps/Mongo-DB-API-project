using Mongo.Database.Models;
using MongoDB.Driver;

namespace Mongo.Database.Interfaces
{
    public interface IBookstoreContext
    {
        IMongoCollection<Book> GetBooksCollection();
    }
}
