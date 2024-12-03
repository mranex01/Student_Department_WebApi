using ASPCoreWebAPICRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreWebAPICRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentInfoContext context;

        public StudentsController(StudentInfoContext context)
        {
            this.context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<Student>>> GetStudent()
        {
            var data = await context.Students.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = await context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();

            }
            else
            {
                return (student);
            }

        }

        [HttpPost]

        public async Task<ActionResult<Student>> CreateStudent(Student std)
        {
            await context.Students.AddAsync(std);
            await context.SaveChangesAsync();
            return Ok(std);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<Student>> UpdateStudent(int id, Student std)
        {

            if (id != std.StudentId)
            {
                return BadRequest();
            }
            context.Entry(std).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(std);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var std = await context.Students.FindAsync(id);

            if(std == null)
            {
                return NotFound();
            }

            context.Students.Remove(std);
            await context.SaveChangesAsync();
            return Ok(std);

        }
    }

}
