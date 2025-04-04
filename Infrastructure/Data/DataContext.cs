using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Genre> Genres { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasIndex(s => s.ISBN).IsUnique();
        
        modelBuilder.Entity<Author>()
            .HasMany(s => s.Books)
            .WithOne(b => b.Author)
            .HasForeignKey(a => a.AuthorId);
        
        modelBuilder.Entity<Genre>()
            .HasMany(b => b.Books)
            .WithOne(g => g.Genre)
            .HasForeignKey(g => g.GenreId);
    }
}