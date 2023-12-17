using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopASCLibrary.Commands.Category;
using ShopASCLibrary.Commands.CategoryCommand;
using ShopASCLibrary.Data.Context;
using ShopASCLibrary.Exception;
using ShopASCLibrary.Queries.CategoryQuery;

namespace ShopASCAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMediator _mediator;

        public CategoryController(ApplicationDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _mediator.Send(new GetAllCategoriesQuery());
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _mediator.Send(new GetCategoryByIdQuery { Id = id });

            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
        {
            var categoryId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetCategoryById), new { id = categoryId }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                var deleteCommand = new DeleteCategoryCommand(id);
                await _mediator.Send(deleteCommand);

                return NoContent(); // Ou qualquer outro código de status apropriado
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }

}
