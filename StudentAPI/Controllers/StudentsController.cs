using StudentAPI.Models;
using StudentAPI.Repository;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace StudentAPI.Controllers
{
    public class StudentsController : ApiController
    {
        private readonly StudentRepository _studentRepository = new StudentRepository();

        public StudentsController(){}

        // GET: api/Students
        public IQueryable<Student> GetStudents()
        {
            return (IQueryable<Student>)_studentRepository.GetStudents();
        }

        // GET: api/Students/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult GetStudent(int id)
        {
            Student student = _studentRepository.FindStudentById(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // PUT: api/Students/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudent(int id, Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.StudentId)
            {
                return BadRequest();
            }

            try
            {
                _studentRepository.UpdateStudent(student);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_studentRepository.FindStudentById(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Students
        [ResponseType(typeof(Student))]
        public IHttpActionResult PostStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _studentRepository.AddStudent(student);

            return CreatedAtRoute("DefaultApi", new { id = student.StudentId }, student);
        }

        // DELETE: api/Students/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult DeleteStudent(int id)
        {
            Student student = _studentRepository.FindStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            _studentRepository.DeleteStudent(id);

            return Ok(student);
        }
    }
}