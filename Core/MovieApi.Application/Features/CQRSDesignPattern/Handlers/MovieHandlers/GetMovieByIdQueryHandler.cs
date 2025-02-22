using MovieApi.Application.Features.CQRSDesignPattern.Queries.CategoryQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.MovieQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Result.MovieResults;
using MoviewApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieByIdQueryHandler
    {
        private readonly MovieContext _movieContext;

        public GetMovieByIdQueryHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task<GetMovieByIdQueryResult> Handle(GetMovieByIdQuery getMovieByIdQuery,CancellationToken cancellationToken)
        {
            var value = await _movieContext.Movies.FindAsync(new object[] { getMovieByIdQuery.MovieId }, cancellationToken);

            if(value is not null)
            {
                return new GetMovieByIdQueryResult
                {
                    MovieId = value.MovieId,
                    CoverImageUrl = value.CoverImageUrl,
                    CreatedYear = value.CreatedYear,
                    Description = value.Description,
                    Duration = value.Duration,
                    Rating = value.Rating,
                    ReleaseDate = value.ReleaseDate,
                    Status = value.Status,
                    Title = value.Title
                };
            }

            return null;
        }
    }
}
