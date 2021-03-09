using StudentAPI.Models;
using System;
using System.Data.Entity;

namespace StudentAPI.Context
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            context.Students.Add(new Student
            {
                StudentId = 1,
                StudentName = "Suneel Kumar Biyyapu",
                StudentAge = 30,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CreatedBy = "Suneel",
                ModifiedBy = "Suneel"
            });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}