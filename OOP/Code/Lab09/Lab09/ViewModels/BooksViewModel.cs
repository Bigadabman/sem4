using LibraryApp.Data;
using LibraryApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Linq;
using System.Windows.Input;

namespace LibraryApp.ViewModels
{
    public class BooksViewModel : INotifyPropertyChanged
    {
        private readonly LibraryContext _context;
        public ObservableCollection<Book> Books { get; } = new();
        public ObservableCollection<Author> Authors { get; } = new();
        public ObservableCollection<Genre> Genres { get; } = new();

        private Book _selectedBook;
        public Book SelectedBook
        {
            get => _selectedBook;
            set { _selectedBook = value; OnPropertyChanged(); }
        }

        public string SearchText { get; set; }
        public ICommand LoadCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand SearchCommand { get; }

        public BooksViewModel(LibraryContext context)
        {
            _context = context;
            LoadCommand = new RelayCommand(async _ => await LoadAsync());
            AddCommand = new RelayCommand(async _ => await AddAsync());
            EditCommand = new RelayCommand(async _ => await EditAsync(), _ => SelectedBook != null);
            DeleteCommand = new RelayCommand(async _ => await DeleteAsync(), _ => SelectedBook != null);
            SearchCommand = new RelayCommand(async _ => await SearchAsync());
            Task.Run(async () => await LoadAsync());
        }

        public async Task LoadAsync()
        {
            Books.Clear();
            foreach (var b in await _context.Books.Include(b => b.Author).Include(b => b.Genre).ToListAsync())
                Books.Add(b);

            Authors.Clear();
            foreach (var a in await _context.Authors.ToListAsync())
                Authors.Add(a);

            Genres.Clear();
            foreach (var g in await _context.Genres.ToListAsync())
                Genres.Add(g);
        }

        public async Task AddAsync()
        {
            var newBook = new Book
            {
                Title = "Новая книга",
                Year = 2024,
                AuthorId = Authors.FirstOrDefault()?.AuthorId ?? 0,
                GenreId = Genres.FirstOrDefault()?.GenreId ?? 0
            };
            _context.Books.Add(newBook);
            await _context.SaveChangesAsync();
            await LoadAsync();
        }

        public async Task EditAsync()
        {
            if (SelectedBook != null)
            {
                await _context.SaveChangesAsync();
                await LoadAsync();
            }
        }

        public async Task DeleteAsync()
        {
            if (SelectedBook != null)
            {
                _context.Books.Remove(SelectedBook);
                await _context.SaveChangesAsync();
                await LoadAsync();
            }
        }

        public async Task SearchAsync()
        {
            Books.Clear();
            var query = _context.Books.Include(b => b.Author).Include(b => b.Genre).AsQueryable();
            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                query = query.Where(b =>
                    b.Title.Contains(SearchText) ||
                    b.Author.Name.Contains(SearchText) ||
                    b.Genre.Name.Contains(SearchText)
                );
            }
            foreach (var b in await query.ToListAsync())
                Books.Add(b);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}