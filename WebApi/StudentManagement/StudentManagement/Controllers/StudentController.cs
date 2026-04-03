using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Models;
using StudentManagement.Models.Entities;

namespace StudentManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {
        private readonly StudentDbContext dbContext;
        public StudentController(StudentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = dbContext.Students.ToList();
            return Ok(students);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetStudentById(int id)
        {
            var studentById = dbContext.Students.Find(id);

            if(studentById == null)
            {
                return StatusCode(404);
            }

            return Ok(studentById);

        }

        [HttpPut]
        public IActionResult AddStudent(AddStudentDto addStudent)
        {
            var studentEntity = new Student()
            {
                Name = addStudent.Name,
                Email = addStudent.Email,
                Course = addStudent.Course
            };

            dbContext.Students.Add(studentEntity);
            dbContext.SaveChanges();

            return Ok(studentEntity);
        }

        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            var studentEntity = dbContext.Students.Find(id);

            if(studentEntity == null)
            {
                return StatusCode(404);
            }

            dbContext.Students.Remove(studentEntity);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
