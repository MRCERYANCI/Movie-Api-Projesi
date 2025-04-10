using MediatR;
using MovieApi.Application.Features.MediatorDesingPattern.Commands.TagCommands;
using MoviewApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesingPattern.Handlers.TagHandlers
{
    public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand>
    {
        private readonly MovieContext _movieContext;

        public UpdateTagCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            var value = await _movieContext.Tags.FindAsync(new object[] { request.TagId }, cancellationToken);

            if(value is not null)
            {
                value.Title = request.Title;
                _movieContext.Tags.Update(value);
                await _movieContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
