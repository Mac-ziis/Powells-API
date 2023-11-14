using Microsoft.EntityFrameworkCore;

namespace  PowellApi.Models
{
  public class PowellApiContext : DbContext
  {
    public DbSet<Book> Books {get; set;}

    public PowellApiContext(DbContextOptions<PowellApiContext> options) : base(options)
    {
    }

      protected override void OnModelCreating(ModelBuilder builder)
      {
        builder.Entity<Book>()
        .HasData(
          new Book { BookId = 1, Title = "Linux For Dummies", Author = "Fred Jumpturd", Summary = "Summary1Summary1Summary1Summary1Summary1Summary1"},
          new Book { BookId = 2, Title = "Api for Dummies", Summary = "Summary2Summary2Summary2Summary2Summary2" },
          new Book { BookId = 3, Title = "C# for Dummies", Summary = "Summary3Summary3Summary3Summary3Summary3"}
        );
      }

        internal object GetBooks(PagedParameters bookParameters)
        {
            throw new NotImplementedException();
        }
    }
  }