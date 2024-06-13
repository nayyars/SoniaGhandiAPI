using Microsoft.AspNetCore.Mvc;
using SoniaGhandiAPI.DataLayer;
using SoniaGhandiAPI.Models;
using SoniaGhandiAPI.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SoniaGhandiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //private readonly StudentRepository _studentRepository;
        //public StudentsController(StudentRepository studentRepository)
        //{
        //    _studentRepository = studentRepository;
        //}
        private readonly IStudentRepository _IStudentRepository;

        public StudentsController(IStudentRepository IstudentRepository) {
            _IStudentRepository = IstudentRepository;
        }
        // GET: api/<StudentsController>
        [HttpGet]
        public IActionResult Get()
        {
             var student = _IStudentRepository.GetStudents();

            if (student == null)
            {
                return NotFound();
            }
            return Ok(student); 
        }
        [HttpPost]
        public IActionResult CreateStudent([FromBody] StudentViewModel student)
        {
            if (student == null)
            {
                return BadRequest("Student is null.");
            }

            // Add the new student to the repository
            var createdStudent =  _IStudentRepository.InsertStudent(student);
            var studentList = _IStudentRepository.GetStudents();
            return Ok(studentList);
            // If creation is successful, return a 201 Created response with the location of the new resource
            // return CreatedAtAction(nameof(GetStudentById), new { id = createdStudent.StudentId }, createdStudent);
        }
        // GET api/<StudentsController>/5
    
        // GET method to retrieve a student by ID
        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student =  _IStudentRepository.GetStudentByID(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // POST api/<StudentsController>
       

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
