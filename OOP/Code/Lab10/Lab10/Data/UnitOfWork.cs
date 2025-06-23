using SimpleWpfOop.Models;

namespace SimpleWpfOop.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IRepository<Student> Students { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Students = new StudentRepository(_context);
        }

        public void Save()
        {
            // For in-memory, nothing needed. If using a database, would save all changes here.
        }
    }
}