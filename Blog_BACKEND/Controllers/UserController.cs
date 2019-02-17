using System;
using System.Linq;
using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog_BACKEND.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly BlogDbContext _blogDbContext;

        public UserController(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }

        /// <summary>
        /// GET /api/user
        /// </summary>
        /// <returns>Все пользователи. Массив объектов</returns>
        [HttpGet("")]
        public IActionResult GetAll()
        {
            var users = _blogDbContext.User.ToList();

            return Ok(users);
        }

        /// <summary>
        /// GET api/user/6F9619FF-8B86-D011-B42D-00CF4FC964FF
        /// </summary>
        /// <returns>Конкретного пользователя. Массив с объектом</returns>
        /// <param name="id">Identifier.</param>
        [HttpGet("{id:int}")]
        public IActionResult GetUser(int id)
        {
            var user = _blogDbContext.User.FirstOrDefault(u => u.Id == id);

            if (user == null)
                return NotFound(string.Format("Такого пользователя нет в системе"));

            return Ok(new
            {
                id = user.Id,
                firstName = user.FirstName,
                lastName = user.LastName,
                creationDate = user.CreationDate,
                lastDate = user.LastLoginDate
            });
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