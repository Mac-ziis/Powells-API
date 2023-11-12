using PowellApi.Models;

namespace PowellApi.Contracts
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        PagedList<Book> GetBooks(PagedParameters bookParameters);
        Book GetBookById(Guid bookId);
    }
}