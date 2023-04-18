using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WAVets2Tech_API.Models;
using Microsoft.EntityFrameworkCore;

namespace WAVets2Tech_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly Wavets2TechContext _dbContext;

        public StudentController(Wavets2TechContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        
        [Route("GetStudents")]

        public async Task<IActionResult> Get()
        {
            var students = await _dbContext.Students.ToListAsync();
            return Ok(students);
        }
    }
}
