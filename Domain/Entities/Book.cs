using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Book
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(50)]
    public string Title { get; set; }
    
    [Range(1450, 2100)]
    public int Year { get; set; }

    [Required]
    [MaxLength(13)]
    [MinLength(10)]
    public string ISBN { get; set; }
    
    [Range(0, 21450)]
    public int Pages { get; set; }
    
    [MaxLength(250)]
    public string? Description { get; set; }
    
    public int AuthorId { get; set; }
    public int GenreId { get; set; }

    public Genre Genre { get; set; }
    public Author Author { get; set; }
}