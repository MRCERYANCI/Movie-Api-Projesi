using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MoviewApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandle
    {
        private readonly MovieContext _movieContext;

        public UpdateCategoryCommandHandle(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task Handle(UpdateCategoryCommand updateCategoryCommand)
        {
            var category = await _movieContext.Categories.FindAsync(updateCategoryCommand.CategoryId);
            
            if(category is not null)
            {
                category.CategoryName = updateCategoryCommand.CategoryName;
                await _movieContext.SaveChangesAsync();
            }
        }
    }
}
