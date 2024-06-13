using Microsoft.AspNetCore.Mvc;
using SoniaGhandiAPI.Models;
using SoniaGhandiAPI.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SoniaGhandiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitTeacherController : ControllerBase
    {
        private IRepository<TeacherViewModel> _repositoryTeacher;
        public InitTeacherController(IRepository<TeacherViewModel> repositoryTeacher)
        {
            _repositoryTeacher = repositoryTeacher;
        }

        // GET: api/<InitTeacherController>
        [HttpGet]
        public IActionResult Get()
        {
            TeacherUpdateViewModel viewModel = _repositoryTeacher.GetUpdateTeacher();

            return Ok(viewModel);
        }

        // GET api/<InitTeacherController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<InitTeacherController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<InitTeacherController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InitTeacherController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
