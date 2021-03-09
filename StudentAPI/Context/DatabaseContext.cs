using StudentAPI.Models;
using System.Data.Entity;

namespace StudentAPI.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=DefaultConnection")
        {
        }

        public IDbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
    }
}