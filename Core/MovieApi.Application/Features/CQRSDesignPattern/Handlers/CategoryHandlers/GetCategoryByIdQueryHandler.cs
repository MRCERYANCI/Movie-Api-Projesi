using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.CategoryQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Result.CategoryResults;
using MoviewApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly MovieContext _movieContext;

        public GetCategoryByIdQueryHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery getCategoryByIdQuery, CancellationToken cancellationToken)
        {
            var value = await _movieContext.Categories.FindAsync(new object[] { getCategoryByIdQuery.CategoryId }, cancellationToken);
            if (value is not null)
            {
                return new GetCategoryByIdQueryResult
                {
                    CategoryId = value.CategoryId,
                    CategoryName = value.CategoryName
                };
            }
            return null;
        }
    }
}
