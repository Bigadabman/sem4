
using LibraryApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Linq;
using System.Windows.Input;
using System;

namespace LibraryApp.ViewModels
{
    public class BookLoansViewModel : INotifyPropertyChanged
    {
        private readonly LibraryContext _context;
        public ObservableCollection<BookLoan> BookLoans { get; } = new();
        public ObservableCollection<Book> Books { get; } = new();
        public ObservableCollection<Reader> Readers { get; } = new();

        public Book SelectedBook { get; set; }
        public Reader SelectedReader { get; set; }
        public BookLoan SelectedBookLoan { get; set; }

        public ICommand LoadCommand { get; }
        public ICommand LoanCommand { get; }
        public ICommand ReturnCommand { get; }

        public BookLoansViewModel(LibraryContext context)
        {
            _context = context;
            LoadCommand = new RelayCommand(async _ => await LoadAsync());
            LoanCommand = new RelayCommand(async _ => await LoanBookAsync(), _ => SelectedBook != null && SelectedReader != null);
            ReturnCommand = new RelayCommand(async _ => await ReturnBookAsync(), _ => SelectedBookLoan != null);
            Task.Run(async () => await LoadAsync());
        }

        public async Task LoadAsync()
        {
            BookLoans.Clear();
            foreach (var l in await _context.BookLoans
                .Include(bl => bl.Book)
                .ThenInclude(b => b.Author)
                .Include(bl => bl.Reader)
                .ToListAsync())
                BookLoans.Add(l);

            Books.Clear();
            foreach (var b in await _context.Books.Include(b => b.Author).ToListAsync())
                Books.Add(b);

            Readers.Clear();
            foreach (var r in await _context.Readers.ToListAsync())
                Readers.Add(r);
        }

        // Асинхронная транзакция: выдача книги
        public async Task LoanBookAsync()
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var loan = new BookLoan
                {
                    BookId = SelectedBook.BookId,
                    ReaderId = SelectedReader.ReaderId,
                    LoanDate = DateTime.Now
                };
                _context.BookLoans.Add(loan);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                await LoadAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
            }
        }

        // Возврат книги (удаление выдачи)
        public async Task ReturnBookAsync()
        {
            if (SelectedBookLoan != null)
            {
                _context.BookLoans.Remove(SelectedBookLoan);
                await _context.SaveChangesAsync();
                await LoadAsync();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}