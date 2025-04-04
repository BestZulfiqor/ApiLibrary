using System.ComponentModel.DataAnnotations;
namespace Domain.Entities;
public class Author
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    
    public DateTimeOffset BirthDate { get; set; }
    
    public string Country { get; set; }

    [MaxLength(200)]
    public string Biography { get; set; }

    public List<Book> Books { get; set; }
}