using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.MovieQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly CreateMovieCommandHandler _createMovieCommandHandler;
        private readonly UpdateMovieCommandHandler _updateMovieCommandHandler;
        private readonly RemoveMovieCommandHandler _removeMovieCommandHandler;
        private readonly GetMovieQueryHandler _getMovieQueryHandler;
        private readonly GetMovieByIdQueryHandler _getMovieByIdQueryHandler;

        public MoviesController(CreateMovieCommandHandler createMovieCommandHandler, UpdateMovieCommandHandler updateMovieCommandHandler, RemoveMovieCommandHandler removeMovieCommandHandler, GetMovieQueryHandler getMovieQueryHandler, GetMovieByIdQueryHandler getMovieByIdQueryHandler)
        {
            _createMovieCommandHandler = createMovieCommandHandler;
            _updateMovieCommandHandler = updateMovieCommandHandler;
            _removeMovieCommandHandler = removeMovieCommandHandler;
            _getMovieQueryHandler = getMovieQueryHandler;
            _getMovieByIdQueryHandler = getMovieByIdQueryHandler;
        }


        [HttpPost]
        public async Task<IActionResult> CreateMovie(CreateMovieCommand createMovieCommand)
        {
            await _createMovieCommandHandler.Handle(createMovieCommand);
            return Ok(new
            {
                Status = "200",
                Message = "Film Ekleme İşlemi Başarılıdır"
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetMovie()
        {
            return Ok(await _getMovieQueryHandler.Handle(HttpContext.RequestAborted));
        }

        [HttpGet("{MovieId}")]
        public async Task<IActionResult> GetByIdMovie(int MovieId)
        {
            return Ok(await _getMovieByIdQueryHandler.Handle(new GetMovieByIdQuery(MovieId), HttpContext.RequestAborted));
        }

        [HttpDelete("{MovieId}")]
        public async Task<IActionResult> DeleteMovie(int MovieId)
        {
            await _removeMovieCommandHandler.Handle(new RemoveMovieCommand(MovieId), HttpContext.RequestAborted);
            return Ok(new
            {
                Status = "200",
                Message = "Film Silme İşlemi Başarılıdır"
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovie(UpdateMovieCommand updateMovieCommand)
        {
            await _updateMovieCommandHandler.Handle(updateMovieCommand);
            return Ok(new
            {
                Status = "200",
                Message = "Film Güncelleme İşlemi Başarılıdır"
            });
        }
    }
}
