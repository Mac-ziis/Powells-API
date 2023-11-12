using PowellApi.Contracts;
using PowellApi.Models;

namespace PowellApi.Repository
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(PowellApiContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public PagedList<Book> GetBooks(PagedParameters bookParameters)
        {
            return PagedList<Book>.ToPagedList(FindAll(),
                bookParameters.PageNumber,
                bookParameters.PageSize);
        }

        public Book GetBookById(Guid bookId)
        {
            return FindByCondition(cust => cust.BookId.Equals(bookId))
                .DefaultIfEmpty(new Book())
                .FirstOrDefault();
        }

    }
}