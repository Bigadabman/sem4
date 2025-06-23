using System.Linq;
using System.Windows;
using SimpleWpfOop.Data;
using SimpleWpfOop.Models;

namespace SimpleWpfOop
{
    public partial class MainWindow : Window
    {
        private readonly IUnitOfWork _unitOfWork;

        public MainWindow()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork(new AppDbContext());
            RefreshList();
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NameBox.Text))
            {
                var newStudent = new Student { Id = _unitOfWork.Students.GetAll().Count() + 1, Name = NameBox.Text };
                _unitOfWork.Students.Add(newStudent);
                _unitOfWork.Save();
                RefreshList();
                NameBox.Text = "";
            }
        }

        private void RemoveStudent_Click(object sender, RoutedEventArgs e)
        {
            if (StudentList.SelectedItem is Student student)
            {
                _unitOfWork.Students.Remove(student);
                _unitOfWork.Save();
                RefreshList();
            }
        }

        private void RefreshList()
        {
            StudentList.ItemsSource = null;
            StudentList.ItemsSource = _unitOfWork.Students.GetAll().ToList();
            StudentList.DisplayMemberPath = "Name";
        }
    }
}