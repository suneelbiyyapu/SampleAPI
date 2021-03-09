using StudentAPI.Context;
using StudentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentAPI.Repository
{
    public class StudentRepository : IStudentRepository
    {
        DatabaseContext context = new DatabaseContext();
        public void AddStudent(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }

        public void DeleteStudent(int studentId)
        {
            Student student = context.Students.Find(studentId);
            context.Students.Remove(student);
            context.SaveChanges();
        }

        public Student FindStudentById(int Id)
        {
            var student = (from r in context.Students where r.StudentId == Id select r).FirstOrDefault();
            return student;
        }

        public IEnumerable<Student> GetStudents()
        {
            return context.Students;
        }

        public void UpdateStudent(Student student)
        {
            context.Entry(student).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
    }
}