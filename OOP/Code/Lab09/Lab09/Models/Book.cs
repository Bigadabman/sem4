namespace LibraryApp.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public ICollection<BookLoan> BookLoans { get; set; }
    }
}