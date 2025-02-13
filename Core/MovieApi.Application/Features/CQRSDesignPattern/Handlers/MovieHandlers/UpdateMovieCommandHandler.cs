using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MoviewApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class UpdateMovieCommandHandler
    {
        private readonly MovieContext _movieContext;

        public UpdateMovieCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task Handle(UpdateMovieCommand updateMovieCommand)
        {
            var movie = await _movieContext.Movies.FindAsync(updateMovieCommand.MovieId);

            if(movie is not null)
            {
                movie.Status = updateMovieCommand.Status;
                movie.Title = updateMovieCommand.Title;
                movie.Description = updateMovieCommand.Description;
                movie.CoverImageUrl = updateMovieCommand.CoverImageUrl;
                movie.Rating = updateMovieCommand.Rating;
                movie.Duration = updateMovieCommand.Duration;
                movie.CreatedYear = updateMovieCommand.CreatedYear;
                movie.CategoryId = updateMovieCommand.CategoryId;
                movie.ReleaseDate = updateMovieCommand.ReleaseDate;

                _movieContext.Movies.Update(movie)
                await _movieContext.SaveChangesAsync();
        }
    }
}
