using LibraryItems.Api.Entities;
using LibraryItems.Api.Repositries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryItems.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryItemsController : Controller
    {
        private readonly ILibraryItemRepository _libraryItemRepository;

        public LibraryItemsController(ILibraryItemRepository libraryItemRepository)
        {
            _libraryItemRepository = libraryItemRepository;
        }

        [HttpGet]
        [Route("GetLibraryItems")]
        public async Task<ActionResult<IEnumerable<LibraryItem>>> GetCustomer()
        {
            var item = await _libraryItemRepository.GetItems();
            //List<Category> customer = new List<Category>();
            return Ok(item);
        }

        [HttpPost]
        [Route("CreateLibraryItem")]
        public async Task<ActionResult<Category>> AddAuthor(LibraryItem item)
        {
            var dbItem = await _libraryItemRepository.AddLibItem(item); 

            if (dbItem == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{item.Title} could not be added.");

            }

            return Ok(dbItem);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Category>>> DeleteLibraryItem(int id)
        {
            (bool status, string message) = await _libraryItemRepository.DeleteLibItem(id); 

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return Ok(await GetCustomer());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Category>>> UpdateAuthor(int id, LibraryItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            LibraryItem dbItem = await _libraryItemRepository.UpdateLibItem(item); 

            if (dbItem == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{item.Title} could not be updated");
            }

            return Ok(await GetCustomer());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLibItem(int id)
        {
            LibraryItem dbItem = await _libraryItemRepository.GetLibItem(id); 

            if (dbItem == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No category found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, dbItem);
        }

    }
}
