using System.Collections.Generic;
using DevOpsStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(new List<StoreItem>
            {
                new StoreItem()
                {
                    Id = "1",
                    Name = "T-shirt"
                },
                new StoreItem()
                {
                    Id = "2",
                    Name = "hat"
                },
                new StoreItem()
                {
                    Id = "3",
                    Name = "shoes"
                }
            });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}