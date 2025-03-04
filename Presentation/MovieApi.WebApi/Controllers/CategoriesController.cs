using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.CategoryQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;

        public CategoriesController(CreateCategoryCommandHandler createCategoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler, GetCategoryQueryHandler getCategoryQueryHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler)
        {
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;
            _removeCategoryCommandHandler = removeCategoryCommandHandler;
            _getCategoryQueryHandler = getCategoryQueryHandler;
            _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand createCategoryCommand)
        {
            await _createCategoryCommandHandler.Handle(createCategoryCommand);
            return Ok(new
            {
                Status = "200",
                Message = "Kategori Ekleme İşlemi Başarılıdır"
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetCategory()
        {
            return Ok(await _getCategoryQueryHandler.Handle(HttpContext.RequestAborted));
        }

        [HttpGet("{CategoryId}")]
        public async Task<IActionResult> GetByIdCategory(int CategoryId)
        {
            return Ok(await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(CategoryId), HttpContext.RequestAborted));
        }

        [HttpDelete("{CategoryId}")]
        public async Task<IActionResult> DeleteCategory(int CategoryId)
        {
            await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(CategoryId), HttpContext.RequestAborted);
            return Ok(new
            {
                Status = "200",
                Message = "Kategori Silme İşlemi Başarılıdır"
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand updateCategoryCommand)
        {
            await _updateCategoryCommandHandler.Handle(updateCategoryCommand);
            return Ok(new
            {
                Status = "200",
                Message = "Kategori Güncelleme İşlemi Başarılıdır"
            });
        }
        
    }
}
