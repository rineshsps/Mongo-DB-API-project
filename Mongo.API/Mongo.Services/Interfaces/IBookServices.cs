using Mongo.Database.Models;
using System.Collections.Generic;

namespace Mongo.Services.Interfaces
{
    public interface IBookServices
    {
        List<Book> GetBooks();
        Book GetBook(string id);
        Book Create(Book book);
        Book Update(Book book);
        void Delete(string id);
    }
}
