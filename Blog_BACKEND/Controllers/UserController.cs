using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Mvc;

namespace Blog_BACKEND.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly BlogDbContext _blogDbContext;

        public UserController(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }

        // GET api/values
        [HttpGet]
        public ActionResult Get(Author )
        {
            var user = _blogDbContext.Users
                .include(u => u.Publications)
                .FirstOrDefault(u => u.UserGUID == Author);
            return new string[] { "value1", "value2" };
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
