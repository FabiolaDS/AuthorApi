
using AuthorApi.Model;
using Microsoft.EntityFrameworkCore;

namespace AuthorApi.Persistence
{
    public class LibrayDbContext:DbContext
    {
        public  DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source =author.sqlite");
        }
    }
    
}