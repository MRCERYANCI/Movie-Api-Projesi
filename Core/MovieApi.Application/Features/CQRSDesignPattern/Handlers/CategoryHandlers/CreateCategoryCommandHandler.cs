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
    public class CreateCategoryCommandHandler
    {
        private readonly MovieContext _movieContext;

        public CreateCategoryCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task Handle(CreateCategoryCommand createCategoryCommand)
        {
            await _movieContext.Categories.AddAsync(new Category
            {
                CategoryName = createCategoryCommand.CategoryName
            });

            await _movieContext.SaveChangesAsync();
        }
    }
}
