using Mongo.Database.Interfaces;
using Mongo.Database.Models;
using Mongo.Services.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Mongo.Services
{
    public class BookServices : IBookServices
    {
        private readonly IMongoCollection<Book> _books;

        public BookServices(IBookstoreContext db)
        {
            _books = db.GetBooksCollection();
        }

        public Book Create(Book book)
        {
            _books.InsertOne(book);
            return book;
        }

        public void Delete(string id)
        {
            _books.DeleteOne(book => book.Id == id);
        }

        public Book GetBook(string id) => _books.Find(book => book.Id == id).First();

        public List<Book> GetBooks() => _books.Find(book => true).ToList();

        public Book Update(Book book)
        {
            GetBook(book.Id);
            _books.ReplaceOne(b => b.Id == book.Id, book);
            return book;
        }
    }
}
