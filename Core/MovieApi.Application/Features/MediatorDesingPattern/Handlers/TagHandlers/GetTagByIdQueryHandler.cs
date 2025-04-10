using MediatR;
using MovieApi.Application.Features.MediatorDesingPattern.Queries.TagQueries;
using MovieApi.Application.Features.MediatorDesingPattern.Results.TagResults;
using MoviewApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesingPattern.Handlers.TagHandlers
{
    public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, GetTagByIdQueryResult>
    {
        private readonly MovieContext _movieContext;

        public GetTagByIdQueryHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task<GetTagByIdQueryResult> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {;
            var value = await _movieContext.Tags.FindAsync(new object[] { request.id }, cancellationToken);
            return new GetTagByIdQueryResult
            {
                TagId = value.TagId,
                Title = value.Title
            };
        }
    }
}
