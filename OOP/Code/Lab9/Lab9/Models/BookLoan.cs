
namespace LibraryApp.Models
{public class BookLoan
{
    public int BookLoanId { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; }
    public int ReaderId { get; set; }
    public Reader Reader { get; set; }
    public DateTime LoanDate { get; set; }
}}