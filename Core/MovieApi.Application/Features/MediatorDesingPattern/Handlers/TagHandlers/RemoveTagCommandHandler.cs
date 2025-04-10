using MediatR;
using MovieApi.Application.Features.MediatorDesingPattern.Commands.CastCommands;
using MoviewApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesingPattern.Handlers.TagHandlers
{
    public class RemoveTagCommandHandler : IRequestHandler<RemoveCastCommand>
    {
        private readonly MovieContext _movieContext;

        public RemoveTagCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task Handle(RemoveCastCommand request, CancellationToken cancellationToken)
        {
            var value = await _movieContext.Tags.FindAsync((new object[] { request.CastId }, cancellationToken));
            if (value is not null)
            {
                _movieContext.Remove(value);
                await _movieContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
