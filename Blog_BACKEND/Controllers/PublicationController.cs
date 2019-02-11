using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog_BACKEND.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublicationsController : Controller
    {

        private readonly BlogDbContext _blogDbContext;

        public PublicationsController(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>Получение всех публикаций</returns>
        [HttpGet("")]
        public IActionResult GetAll()
        {
            var publications = _blogDbContext.Publications.ToList();

            return Ok(publications);
        }


        // GET api/publication/1
        [HttpGet("{id:int}")]
        public IActionResult GetPublication(int id)
        {
            var publication = _blogDbContext.Publications.FirstOrDefault(p => p.IdPublication == id);

            if (publication == null) return NotFound(string.Format("Такой публикации нет"));

            return Ok(new
            {
                title = publication.Title,
                text = publication.Text,
                author = publication.Author,
            });
        }

        // GET api/values/5
        /*[HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
