using System.Collections.Generic;
using SimpleWpfOop.Models;

namespace SimpleWpfOop.Data
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students;
        }

        public void Add(Student entity)
        {
            _context.Students.Add(entity);
        }

        public void Remove(Student entity)
        {
            _context.Students.Remove(entity);
        }
    }
}