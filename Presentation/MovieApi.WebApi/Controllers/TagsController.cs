using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.MediatorDesingPattern.Commands.TagCommands;
using MovieApi.Application.Features.MediatorDesingPattern.Queries.TagQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> TagList()
        {
            var values = await _mediator.Send(new GetTagQuery());
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag(CreateTagCommand createTagCommand)
        {
            await _mediator.Send(createTagCommand);
            return Ok(new
            {
                Status = "200",
                Message = "Tag Ekleme İşlemi Başarılıdır"
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            await _mediator.Send(new RemoveTagCommand(id));

            return Ok(new
            {
                Status = "200",
                Message = "Tag Silme İşlemi Başarılıdır"
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTag(UpdateTagCommand updateTagCommand)
        {
            await _mediator.Send(updateTagCommand);

            return Ok(new
            {
                Status = "200",
                Message = "Tag Güncelleme İşlemi Başarılıdır"
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTagById(int id)
        {
            var value = await _mediator.Send(new GetTagByIdQuery(id));
            return Ok(value);
        }
    }
}
