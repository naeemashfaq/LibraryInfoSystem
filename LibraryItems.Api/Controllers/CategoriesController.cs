using LibraryItems.Api.Entities;
using LibraryItems.Api.Repositries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryItems.Api.Dtos;

namespace LibraryItems.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private CategoryDto catDto = new CategoryDto();

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Route("GetCategories")]
        public async Task<ActionResult<List<Category>>> GetCustomer()
        {
            var catg = await _categoryRepository.GetItems();
            //List<Category> customer = new List<Category>();
            return Ok(catg);
        }

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<ActionResult<List<Category>>> AddAuthor(Category cat)
        {
            catDto.CategoryName = cat.CategoryName;
            var dbAuthor = await _categoryRepository.AddCategory(cat);

            if (dbAuthor == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{cat.CategoryName} could not be added.");
                
            }

            //return Ok(cat);
            return Ok(await GetCustomer());
        }


        [HttpDelete("{id}")]
       // public async Task<ActionResult<IEnumerable<Category>>> DeleteAuthor(int id)
        public async Task<ActionResult<bool>> DeleteCat(int id)
        {
            bool status = await _categoryRepository.DeleteCategory(id);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, false);
            }
            else
            {
                return Ok(true);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Category>>> UpdateAuthor(int id, Category author)
        {
            if (id != author.Id)
            {
                return BadRequest();
            }

            Category dbAuthor = await _categoryRepository.UpdateCategory(author);

            if (dbAuthor == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{author.CategoryName} could not be updated");
            }

            return Ok(await GetCustomer());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            Category book = await _categoryRepository.GetCategory(id); 

            if (book == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No category found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, book);
        }
    }

}
