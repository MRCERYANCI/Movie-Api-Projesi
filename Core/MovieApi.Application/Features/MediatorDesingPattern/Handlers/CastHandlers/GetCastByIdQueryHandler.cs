using MediatR;
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
    public class GetCastByIdQueryHandler : IRequestHandler<GetCastByIdQuery, GetCastByIdQueryResult>
    {
        private readonly MovieContext _movieContext;

        public GetCastByIdQueryHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task<GetCastByIdQueryResult> Handle(GetCastByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _movieContext.Casts.FindAsync(new object[] { request.CastId }, cancellationToken);
            return new GetCastByIdQueryResult
            {
                CastId = value.CastId,
                Title = value.Title,
                Name = value.Name,
                Surname = value.Surname,
                ImageUrl = value.ImageUrl,
                Overview = value.Overview,
                Biography = value.Biography
            };
        }
    }
}
