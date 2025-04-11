using MediatR;
using MovieApi.Application.Features.MediatorDesingPattern.Commands.CastCommands;
using MovieApi.Application.Features.MediatorDesingPattern.Commands.TagCommands;
using MoviewApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesingPattern.Handlers.TagHandlers
{
    public class RemoveTagCommandHandler : IRequestHandler<RemoveTagCommand>
    {
        private readonly MovieContext _movieContext;

        public RemoveTagCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task Handle(RemoveTagCommand request, CancellationToken cancellationToken)
        {
            var value = await _movieContext.Tags.FindAsync(request.id);
            if (value is not null)
            {
                _movieContext.Tags.Remove(value);
                await _movieContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
