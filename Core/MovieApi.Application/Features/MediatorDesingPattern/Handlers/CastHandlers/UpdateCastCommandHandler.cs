using MediatR;
using MovieApi.Application.Features.MediatorDesingPattern.Commands.CastCommands;
using MoviewApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesingPattern.Handlers.CastHandlers
{
    public class UpdateCastCommandHandler : IRequestHandler<UpdateCastCommand>
    {
        private readonly MovieContext _movieContext;

        public UpdateCastCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task Handle(UpdateCastCommand request, CancellationToken cancellationToken)
        {
            var cast = await _movieContext.Casts.FindAsync(request.CastId);

            if(cast is not null)
            {
                cast.Title = request.Title;
                cast.Name = request.Name;
                cast.Surname = request.Surname;
                cast.ImageUrl = request.ImageUrl;
                cast.Overview = request.Overview;
                cast.Biography = request.Biography;

                _movieContext.Casts.Update(cast);
                await _movieContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
