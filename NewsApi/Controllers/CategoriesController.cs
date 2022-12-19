using Microsoft.AspNetCore.Mvc;
using NewsApi.Model;

namespace NewsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : Controller
    {
        static List<Category> categories = new List<Category>
        {
            new Category{Id = 0, Name = "All"},
            new Category{Id = 1, Name = "Laboratory"}
        };

        /// <summary>
        /// Returns all the categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(categories);
        }

        /// <summary>
        /// Returns a category that matches the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            return Ok(categories.FirstOrDefault(c => c.Id == id));
        }

        /// <summary>
        /// Adds a category
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody] Category category)
        {
            categories.Add(category);
            return Ok();
        }

        /// <summary>
        /// Deletes all the categories with the matching id
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            categories.RemoveAll(c => c.Id == id);
            return Ok();
        }
    }
}
