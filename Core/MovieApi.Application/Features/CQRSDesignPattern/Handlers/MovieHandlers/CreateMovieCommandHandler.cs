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
    public class CreateMovieCommandHandler
    {
        private readonly MovieContext _movieContext;

        public CreateMovieCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task Handle(CreateMovieCommand createMovieCommand)
        {
            await _movieContext.Movies.AddAsync(new Movie
            {
                CoverImageUrl = createMovieCommand.CoverImageUrl,
                Description = createMovieCommand.Description,
                Duration = createMovieCommand.Duration,
                ReleaseDate = createMovieCommand.ReleaseDate,
                CreatedYear = createMovieCommand.CreatedYear,
                Rating = createMovieCommand.Rating,
                Status = createMovieCommand.Status,
                Title = createMovieCommand.Title
            });

            await _movieContext.SaveChangesAsync();
        }
    }
}
