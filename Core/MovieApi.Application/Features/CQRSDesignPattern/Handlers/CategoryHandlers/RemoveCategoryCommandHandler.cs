using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Domain.Entities;
using MoviewApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler
    {
        private readonly MovieContext _movieContext;

        public RemoveCategoryCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task Handle(RemoveCategoryCommand removeCategoryCommand, CancellationToken cancellationToken)
        {
            Category ?category = await _movieContext.Categories.FindAsync(new object[] { removeCategoryCommand.CategoryId }, cancellationToken);

            if(category is not null)
            {
                _movieContext.Categories.Remove(category);
                await _movieContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
