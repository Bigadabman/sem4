
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
    public class AuthorsViewModel : INotifyPropertyChanged
    {
        private readonly LibraryContext _context;
        public ObservableCollection<Author> Authors { get; } = new();

        private Author _selectedAuthor;
        public Author SelectedAuthor
        {
            get => _selectedAuthor;
            set { _selectedAuthor = value; OnPropertyChanged(); }
        }

        public string SearchText { get; set; }
        public ICommand LoadCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand SearchCommand { get; }

        public AuthorsViewModel(LibraryContext context)
        {
            _context = context;
            LoadCommand = new RelayCommand(async _ => await LoadAsync());
            AddCommand = new RelayCommand(async _ => await AddAsync());
            EditCommand = new RelayCommand(async _ => await EditAsync(), _ => SelectedAuthor != null);
            DeleteCommand = new RelayCommand(async _ => await DeleteAsync(), _ => SelectedAuthor != null);
            SearchCommand = new RelayCommand(async _ => await SearchAsync());
            Task.Run(async () => await LoadAsync());
        }

        public async Task LoadAsync()
        {
            Authors.Clear();
            foreach (var a in await _context.Authors.ToListAsync())
                Authors.Add(a);
        }

        public async Task AddAsync()
        {
            var newAuthor = new Author { Name = "Новый автор" };
            _context.Authors.Add(newAuthor);
            await _context.SaveChangesAsync();
            await LoadAsync();
        }

        public async Task EditAsync()
        {
            if (SelectedAuthor != null)
            {
                await _context.SaveChangesAsync();
                await LoadAsync();
            }
        }

        public async Task DeleteAsync()
        {
            if (SelectedAuthor != null)
            {
                _context.Authors.Remove(SelectedAuthor);
                await _context.SaveChangesAsync();
                await LoadAsync();
            }
        }

        public async Task SearchAsync()
        {
            Authors.Clear();
            var query = _context.Authors.AsQueryable();
            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                query = query.Where(a => a.Name.Contains(SearchText));
            }
            foreach (var a in await query.ToListAsync())
                Authors.Add(a);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}