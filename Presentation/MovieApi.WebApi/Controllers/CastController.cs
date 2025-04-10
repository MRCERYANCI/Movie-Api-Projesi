using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.MediatorDesingPattern.Commands.CastCommands;
using MovieApi.Application.Features.MediatorDesingPattern.Queries.CastQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CastController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CastList()
        {
            var values = await _mediator.Send(new GetCastQuery());
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCast(CreateCastCommand createCastCommand)
        {
            await _mediator.Send(createCastCommand);
            return Ok(new
            {
                Status = "200",
                Message = "Kategori Ekleme İşlemi Başarılıdır"
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCast(int id)
        {
            await _mediator.Send(new RemoveCastCommand(id));

            return Ok(new
            {
                Status = "200",
                Message = "Kategori Ekleme İşlemi Başarılıdır"
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCast(UpdateCastCommand updateCastCommand)
        {
            await _mediator.Send(updateCastCommand);

            return Ok(new
            {
                Status = "200",
                Message = "Kategori Ekleme İşlemi Başarılıdır"
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCastById(int id)
        {
            var value = await _mediator.Send(new GetCastByIdQuery(id));
            return Ok(value);
        }

    }
}
