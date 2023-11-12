using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PowellApi.Models;

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
    
  }
}