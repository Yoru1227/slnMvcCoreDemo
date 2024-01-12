using Microsoft.AspNetCore.Mvc;
using prjMvcCoreDemo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace prjMvcCoreDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamePandaQueryServicesController : ControllerBase
    {
        // GET: api/<GamePandaQueryServicesController>
        [HttpGet]
        public IEnumerable<TProduct> Get()
        {
            IEnumerable<TProduct> data = from p in new DbDemoContext().TProducts select p;
            return data;
        }

        // GET api/<GamePandaQueryServicesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GamePandaQueryServicesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GamePandaQueryServicesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GamePandaQueryServicesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
