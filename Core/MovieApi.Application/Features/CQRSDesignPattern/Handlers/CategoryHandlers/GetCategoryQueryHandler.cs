using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Result.CategoryResults;
using MoviewApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    {
        private readonly MovieContext _movieContext;

        public GetCategoryQueryHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task<List<GetCategoryQueryResult>> Handle(CancellationToken cancellationToken)
        {
            var values = await _movieContext.Categories.ToListAsync(cancellationToken);
            if(values is not null)
            {
                return values.Select(x=> new GetCategoryQueryResult
                {
                    CategoryId = x.CategoryId,
                    CategoryName = x.CategoryName
                }).ToList();
            }

            return null;
        }
    }
}
