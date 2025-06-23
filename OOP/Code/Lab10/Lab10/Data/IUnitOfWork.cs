using SimpleWpfOop.Models;

namespace SimpleWpfOop.Data
{
    public interface IUnitOfWork
    {
        IRepository<Student> Students { get; }
        void Save();
    }
}