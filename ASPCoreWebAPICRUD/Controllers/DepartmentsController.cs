using ASPCoreWebAPICRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ASPCoreWebAPICRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly DepartmentContext context;

        public DepartmentsController(DepartmentContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Department>>> GetDepartment()
        {
            var data = await context.Departments.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Department>> GetDepartmentById(int id)
        {
            var department = await context.Departments.FindAsync(id);

            if(department==null)
            {
                return NotFound();
            }
            else
            {
                return (department);
            }
        }

        [HttpPost]

        public async Task<ActionResult<Department>> CreateDepartment(Department dt )
        {
            await context.Departments.AddAsync(dt);
            await context.SaveChangesAsync();
            return Ok(dt);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<Department>> UpdateDepartment(int id, Department dt)
        {
            if (id != dt.DepartmentId)
            {
                return BadRequest();
            }
            context.Entry(dt).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(dt);
        }


        [HttpDelete ("{id}")]

        public async Task<ActionResult<Department>> DeleteDepartment( int id)
        {
            var dt = await context.Departments.FindAsync( id); 
            if(dt==null)
            {
                return NotFound();
            }
            context.Departments.Remove(dt);
            await context.SaveChangesAsync();
            return Ok(dt);
        }

    }
}
