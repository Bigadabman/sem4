
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
    public class GenresViewModel : INotifyPropertyChanged
    {
        private readonly LibraryContext _context;
        public ObservableCollection<Genre> Genres { get; } = new();

        private Genre _selectedGenre;
        public Genre SelectedGenre
        {
            get => _selectedGenre;
            set { _selectedGenre = value; OnPropertyChanged(); }
        }

        public string SearchText { get; set; }
        public ICommand LoadCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand SearchCommand { get; }

        public GenresViewModel(LibraryContext context)
        {
            _context = context;
            LoadCommand = new RelayCommand(async _ => await LoadAsync());
            AddCommand = new RelayCommand(async _ => await AddAsync());
            EditCommand = new RelayCommand(async _ => await EditAsync(), _ => SelectedGenre != null);
            DeleteCommand = new RelayCommand(async _ => await DeleteAsync(), _ => SelectedGenre != null);
            SearchCommand = new RelayCommand(async _ => await SearchAsync());
            Task.Run(async () => await LoadAsync());
        }

        public async Task LoadAsync()
        {
            Genres.Clear();
            foreach (var g in await _context.Genres.ToListAsync())
                Genres.Add(g);
        }

        public async Task AddAsync()
        {
            var newGenre = new Genre { Name = "Новый жанр" };
            _context.Genres.Add(newGenre);
            await _context.SaveChangesAsync();
            await LoadAsync();
        }

        public async Task EditAsync()
        {
            if (SelectedGenre != null)
            {
                await _context.SaveChangesAsync();
                await LoadAsync();
            }
        }

        public async Task DeleteAsync()
        {
            if (SelectedGenre != null)
            {
                _context.Genres.Remove(SelectedGenre);
                await _context.SaveChangesAsync();
                await LoadAsync();
            }
        }

        public async Task SearchAsync()
        {
            Genres.Clear();
            var query = _context.Genres.AsQueryable();
            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                query = query.Where(g => g.Name.Contains(SearchText));
            }
            foreach (var g in await query.ToListAsync())
                Genres.Add(g);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}