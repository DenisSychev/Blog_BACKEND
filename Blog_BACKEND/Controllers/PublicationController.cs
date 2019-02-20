using API.Data;
using Blog_BACKEND.Models.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Blog_BACKEND.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublicationController : ControllerBase
    {

        private readonly BlogDbContext _blogDbContext;

        public PublicationController(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }

        /// <summary>
        /// GET api/publication
        /// </summary>
        /// <returns>Все публикации. Массив объектов</returns>
        [HttpGet("")]
        public IActionResult GetAll()
        {
            var publications = _blogDbContext.Publication.Include(p => p.User).ToList();

            return Ok(publications
                .Select(PublicationMapper.ToResponseModel)
                .ToList());
        }


        /// <summary>
        /// GET api/publication/1
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Получение публикации по её Id</returns>
        /// <param name="id">Id публикации</param>
        [HttpGet("{id:int}")]
        public IActionResult GetPublication(int id)
        {
            var publication = _blogDbContext.Publication
                .Include(p => p.User)
                .FirstOrDefault(p => p.Id == id);

            if (publication == null)
                return NotFound(string.Format("Такой публикации нет"));

            return Ok(PublicationMapper.ToResponseModel(publication));
        }       

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
