using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebUI.Data
{
    public class BookContext : DbContext
    {
        private readonly IConfiguration configuration;

        public DbSet<Book> Books { get; set; }
        public DbSet<Medium> Media { get; set; }

        public BookContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book(1, "Don Quixote - Part 1", "Miguel de Cervantes Saavedra", "The ingenious gentleman Don Quixote of La Mancha", 1605),
                new Book(2, "Don Quixote - Part 1", "Miguel de Cervantes Saavedra", "The ingenious gentleman Don Quixote of La Mancha", 1615)
            );

            modelBuilder.Entity<Medium>().HasData(
                new Medium(1, "Book"),
                new Medium(2, "Audiobook"),
                new Medium(3, "Ebook")
            );

            modelBuilder.Entity<BookMedium>()
                .HasKey(bm => new { bm.BookId, bm.MediumId });
        }
    }
}