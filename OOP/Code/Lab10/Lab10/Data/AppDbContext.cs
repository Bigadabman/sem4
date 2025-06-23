using System.Collections.Generic;
using SimpleWpfOop.Models;

namespace SimpleWpfOop.Data
{
    public class AppDbContext
    {
        public List<Student> Students { get; set; } = new List<Student>();
    }
}