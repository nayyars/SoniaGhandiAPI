using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SoniaGhandiAPI.DataLayer;
using SoniaGhandiAPI.Models;
using SoniaGhandiAPI.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SoniaGhandiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly IRepository<TeacherViewModel> _TeacherRepository;
        public TeachersController(IRepository<TeacherViewModel> teacherRepository)
        {
            _TeacherRepository = teacherRepository;
            // New update
            // Test
            // Added Developer - 2
            int c = 9;
        }

        // GET: api/<TeachersController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<TeacherViewModel>? techList= _TeacherRepository.GetTeachers();
            if (techList==null)
            {
                return NotFound();
            }
            return Ok(techList);
        }

        // GET api/<TeachersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TeachersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TeachersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TeachersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
