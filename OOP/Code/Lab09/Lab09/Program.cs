using LibraryApp;
using LibraryApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var services = new ServiceCollection();
services.AddDbContext<LibraryContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("LibraryDb")));

var provider = services.BuildServiceProvider();

using (var context = provider.GetRequiredService<LibraryContext>())
{
    context.Database.Migrate();

    // Пример CRUD
    var author = new Author { Name = "Достоевский" };
    var genre = new Genre { Name = "Роман" };

    context.Authors.Add(author);
    context.Genres.Add(genre);
    await context.SaveChangesAsync();

    var book = new Book { Title = "Преступление и наказание", Year = 1866, AuthorId = author.AuthorId, GenreId = genre.GenreId };
    context.Books.Add(book);
    await context.SaveChangesAsync();

    // Поиск, фильтрация, сортировка (LINQ)
    var books = await context.Books
        .Include(b => b.Author)
        .Include(b => b.Genre)
        .Where(b => b.Year > 1800 && b.Genre.Name == "Роман")
        .OrderByDescending(b => b.Year)
        .ToListAsync();

    foreach (var b in books)
        Console.WriteLine($"{b.Title} - {b.Author.Name} ({b.Genre.Name}) {b.Year}");

    // Асинхронная транзакция
    using var transaction = await context.Database.BeginTransactionAsync();
    try
    {
        var reader = new Reader { Name = "Иванов И.И." };
        context.Readers.Add(reader);
        await context.SaveChangesAsync();

        var loan = new BookLoan { BookId = book.BookId, ReaderId = reader.ReaderId, LoanDate = DateTime.Now };
        context.BookLoans.Add(loan);
        await context.SaveChangesAsync();

        await transaction.CommitAsync();
    }
    catch
    {
        await transaction.RollbackAsync();
    }

    // Редактирование и удаление
    var firstBook = await context.Books.FirstOrDefaultAsync();
    if (firstBook != null)
    {
        firstBook.Title = "Преступление и Наказание (ред.)";
        await context.SaveChangesAsync();

        context.Books.Remove(firstBook);
        await context.SaveChangesAsync();
    }
}