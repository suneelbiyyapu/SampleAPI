using StudentAPI.Models;
using System.Collections.Generic;

namespace StudentAPI.Repository
{
    public interface IStudentRepository
    {
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int studentId);
        IEnumerable<Student> GetStudents();
        Student FindStudentById(int Id);
    }
}