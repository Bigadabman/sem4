using System.Collections.Generic;

namespace SimpleWpfOop.Data
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Remove(T entity);
    }
}