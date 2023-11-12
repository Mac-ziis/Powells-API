using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PowellApi.Models;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace PowellApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BooksController : ControllerBase
  {
    private readonly PowellApiContext _db;
    public BooksController(PowellApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> Get(string title, string author,  string summary)
    {
        IQueryable<Book> query = _db.Books.AsQueryable();

        if (title != null)
        {
            query = query.Where(entry => entry.Title == title);
        }

        if (author != null)
        {
            query = query.Where(entry => entry.Author == author);
        }

        if (summary != null)
        {
            query = query.Where(entry => entry.Summary == summary);
        }

        return await query.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetBook(int id)
    {
        Book book = await _db.Books.FindAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        return book;
    }

    [HttpPost]
    public async Task<ActionResult<Book>> Post(Book book)
    {
        _db.Books.Add(book);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetBook), new{ id = book.BookId }, book);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> PutBook(int id, Book book)
    {
        if (id != book.BookId)
        {
            return BadRequest();
        }

        _db.Books.Update(book);

        try
        {
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!BookExists(id))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }

        return NoContent();
    }

    // DELETE: api/Books/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var book = await _db.Books.FindAsync(id);
        if (book == null)
        {
            return NotFound();
        }

        _db.Books.Remove(book);
        await _db.SaveChangesAsync();

        return NoContent();
    }

    private bool BookExists(int id)
    {
        return _db.Books.Any(e => e.BookId == id);
    }
  }
}