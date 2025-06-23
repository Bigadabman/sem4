
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
    public class ReadersViewModel : INotifyPropertyChanged
    {
        private readonly LibraryContext _context;
        public ObservableCollection<Reader> Readers { get; } = new();

        private Reader _selectedReader;
        public Reader SelectedReader
        {
            get => _selectedReader;
            set { _selectedReader = value; OnPropertyChanged(); }
        }

        public string SearchText { get; set; }
        public ICommand LoadCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand SearchCommand { get; }

        public ReadersViewModel(LibraryContext context)
        {
            _context = context;
            LoadCommand = new RelayCommand(async _ => await LoadAsync());
            AddCommand = new RelayCommand(async _ => await AddAsync());
            EditCommand = new RelayCommand(async _ => await EditAsync(), _ => SelectedReader != null);
            DeleteCommand = new RelayCommand(async _ => await DeleteAsync(), _ => SelectedReader != null);
            SearchCommand = new RelayCommand(async _ => await SearchAsync());
            Task.Run(async () => await LoadAsync());
        }

        public async Task LoadAsync()
        {
            Readers.Clear();
            foreach (var r in await _context.Readers.ToListAsync())
                Readers.Add(r);
        }

        public async Task AddAsync()
        {
            var newReader = new Reader { Name = "Новый читатель" };
            _context.Readers.Add(newReader);
            await _context.SaveChangesAsync();
            await LoadAsync();
        }

        public async Task EditAsync()
        {
            if (SelectedReader != null)
            {
                await _context.SaveChangesAsync();
                await LoadAsync();
            }
        }

        public async Task DeleteAsync()
        {
            if (SelectedReader != null)
            {
                _context.Readers.Remove(SelectedReader);
                await _context.SaveChangesAsync();
                await LoadAsync();
            }
        }

        public async Task SearchAsync()
        {
            Readers.Clear();
            var query = _context.Readers.AsQueryable();
            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                query = query.Where(r => r.Name.Contains(SearchText));
            }
            foreach (var r in await query.ToListAsync())
                Readers.Add(r);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}