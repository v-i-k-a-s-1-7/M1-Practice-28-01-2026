using Microsoft.AspNetCore.Mvc;
using StudentMarks.Data;

namespace StudentMarks.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ResultController : Controller
    {
        private readonly MarksDbContext marksDbContext;

        public ResultController(MarksDbContext marksDbContext)
        {
            this.marksDbContext = marksDbContext;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = marksDbContext.SubjectMarks.ToList();

            return Ok(students);
        }
    }
}
