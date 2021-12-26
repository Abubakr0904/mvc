using Microsoft.EntityFrameworkCore;
using webapp.Models;

namespace webapp.Data;

public class BookDbContext : DbContext
{
    public BookDbContext(DbContextOptions<BookDbContext> options)
        :base(options) {  }
    public DbSet<Category> Categories { get; set; }
    
}