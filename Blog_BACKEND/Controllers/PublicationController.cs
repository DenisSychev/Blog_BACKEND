using API.Data;
using Blog_BACKEND.Models.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_BACKEND.Controllers
{
    [ApiController]
    [Route("api")]
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
        [HttpGet("[controller]")]
        public IActionResult GetAll()
        {
            var publications = _blogDbContext.Publications.Include(p => p.Author).ToList();

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
        [HttpGet("[controller]/{id:int}")]
        public IActionResult GetPublication(int id)
        {
            var publication = _blogDbContext.Publications
                .Include(p => p.Author)
                .FirstOrDefault(p => p.Id == id);

            if (publication == null)
                return NotFound(string.Format("Такой публикации нет"));

            return Ok(PublicationMapper.ToResponseModel(publication));
        }

        [HttpGet("user/{userId:int}/[controller]")]
        public async Task<IActionResult> GetUserPublications(int userId)
        {
            var publications = await _blogDbContext.Publications
                .Include(p => p.Author)
                .Where(p => p.Author.Id == userId)
                .ToListAsync();

            var response = publications.Select(pub => PublicationMapper.ToResponseModel(pub))
                .ToList();

            return Ok(response);
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
