using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.MediatorDesingPattern.Queries.CastQueries;
using MovieApi.Application.Features.MediatorDesingPattern.Results.CastResults;
using MoviewApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesingPattern.Handlers.CastHandlers
{
    public class GetCastQueryHandler : IRequestHandler<GetCastQuery, List<GetCastQueryResult>>
    {
        private readonly MovieContext _movieContext;

        public GetCastQueryHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task<List<GetCastQueryResult>> Handle(GetCastQuery request, CancellationToken cancellationToken)
        {
            var values = await _movieContext.Casts.AsNoTracking().ToListAsync();
            return values.Select(x => new GetCastQueryResult
            {
                CastId = x.CastId,
                Title = x.Title,
                Name = x.Name,
                Surname = x.Surname,
                ImageUrl = x.ImageUrl,
                Overview = x.Overview,
                Biography = x.Biography
            }).ToList();
        }
    }
}
