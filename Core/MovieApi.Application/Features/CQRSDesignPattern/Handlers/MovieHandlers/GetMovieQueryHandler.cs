using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Result.MovieResults;
using MoviewApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieQueryHandler
    {
        private readonly MovieContext _movieContext;

        public GetMovieQueryHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task<List<GetMovieQueryResult>> Handle(CancellationToken cancellationToken)
        {
            var values = await _movieContext.Movies.Where(x => x.Status == true).ToListAsync(cancellationToken);

            if(values is not null)
            {
                return values.Select(x=>new GetMovieQueryResult
                {
                    MovieId = x.MovieId,
                    CoverImageUrl = x.CoverImageUrl,
                    CreatedYear = x.CreatedYear,
                    Description = x.Description,
                    Duration = x.Duration,
                    Rating = x.Rating,
                    ReleaseDate = x.ReleaseDate,
                    Status = x.Status,
                    Title = x.Title
                }).ToList();
            }

            return null;
        }
    }
}
