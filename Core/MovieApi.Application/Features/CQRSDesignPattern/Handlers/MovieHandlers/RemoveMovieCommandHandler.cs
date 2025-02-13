using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Domain.Entities;
using MoviewApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class RemoveMovieCommandHandler
    {
        private readonly MovieContext _movieContext;

        public RemoveMovieCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task Handle(RemoveMovieCommand removeMovieCommand,CancellationToken cancellationToken)
        {
            Movie ?movie = await _movieContext.Movies.FindAsync(new object[] { removeMovieCommand.MovieId }, cancellationToken);

            if(movie is not null)
            {
                _movieContext.Movies.Remove(movie);
                await _movieContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
