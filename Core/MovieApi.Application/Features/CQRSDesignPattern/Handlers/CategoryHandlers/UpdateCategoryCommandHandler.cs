using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MoviewApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly MovieContext _movieContext;

        public UpdateCategoryCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task Handle(UpdateCategoryCommand updateCategoryCommand)
        {
            var category = await _movieContext.Categories.FindAsync(updateCategoryCommand.CategoryId);
            
            if(category is not null)
            {
                category.CategoryName = updateCategoryCommand.CategoryName;

                _movieContext.Categories.Update(category);
                await _movieContext.SaveChangesAsync();
            }
        }
    }
}
