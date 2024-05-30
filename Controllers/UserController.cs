using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }  
        // GET: api/<UserController>
        [HttpGet]
        [Route("Test")]
        public IEnumerable<string> GetTest()
        {
            return new string[] { "Name", "Diego" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IEnumerable<string> Get(int id)
        {
            return  new string[] { "Name", "Diego", $"id: {id}" }; 
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
