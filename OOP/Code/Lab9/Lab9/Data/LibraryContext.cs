using Microsoft.EntityFrameworkCore;
using LibraryApp.Models;

namespace LibraryApp
{
    public class LibraryContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<BookLoan> BookLoans { get; set; }

        public LibraryContext() { }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Замените строку подключения на вашу или возьмите из appsettings.json (для миграций можно хардкодить)
                optionsBuilder.UseSqlServer("Server=DESKTOP-5MOB7JF;Database=LibraryDbNew;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookLoan>()
                .HasOne(bl => bl.Book)
                .WithMany(b => b.BookLoans)
                .HasForeignKey(bl => bl.BookId);

            modelBuilder.Entity<BookLoan>()
                .HasOne(bl => bl.Reader)
                .WithMany(r => r.BookLoans)
                .HasForeignKey(bl => bl.ReaderId);
        }
    }
}