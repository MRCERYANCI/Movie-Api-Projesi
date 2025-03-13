using MediatR;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Application.Features.MediatorDesingPattern.Commands.CastCommands;
using MovieApi.Domain.Entities;
using MoviewApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesingPattern.Handlers.CastHandlers
{
    public class RemoveCastCommandHandler : IRequestHandler<RemoveCastCommand>
    {
        private readonly MovieContext _movieContext;

        public RemoveCastCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task Handle(RemoveCastCommand request, CancellationToken cancellationToken)
        {
            Cast ?cast = await _movieContext.Casts.FindAsync((new object[] { request.CastId }, cancellationToken));
            if(cast is not null)
            {
                _movieContext.Casts.Remove(cast);
                await _movieContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
