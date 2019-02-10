using System;
using System.Linq;
using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        // GET /api/user
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _blogDbContext.User.ToList();

            return Ok(users);
        }

        // GET api/user/get?guid=6F9619FF-8B86-D011-B42D-00CF4FC964FF
        [HttpGet]
        public IActionResult GetUser(Guid guid)
        {
            var user = _blogDbContext.User.FirstOrDefault(u => u.UserGUID == guid);

            if (user == null)
                return NotFound(string.Format("Такого пользователя нет в системе"));

            return Ok(new
            {
                firstName = user.FirstName,
                userGuid = user.UserGUID,
                creationDate = user.CreationDate,
                lastDate = user.LastLoginDate
            });
        }

        // GET api/values/5
        /*[HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }*/

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
