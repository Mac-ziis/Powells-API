using System.ComponentModel.DataAnnotations;

namespace PowellApi.Models
{
  public class Book
  {
    [Required]
    public string Title { get; set; }
    public int BookId { get; set; }
    public string Author {get; set;}
    public string Summary {get; set; }
  
  }
}