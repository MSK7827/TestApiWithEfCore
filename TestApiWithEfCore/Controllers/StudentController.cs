using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApiWithEfCore.NewFolder;

namespace TestApiWithEfCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly SchoolContext _context;
        private readonly IMapper _mapper;

        public StudentController(SchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Get All Students with Enrollments and Courses
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .ToListAsync();

            return Ok(students);
        }

        // Get Student by Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .FirstOrDefaultAsync(s => s.StudentId == id);

            if (student == null) return NotFound();

            return Ok(student);
        }

        // Create Student
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentCreateDto studentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var student = _mapper.Map<Student>(studentDto);

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return Ok(student); // or return CreatedAtAction with a ReadDto
        }

        // Update Student
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student student)
        {
            if (id != student.StudentId)
                return BadRequest();

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Students.Any(e => e.StudentId == id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        // Delete Student
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
