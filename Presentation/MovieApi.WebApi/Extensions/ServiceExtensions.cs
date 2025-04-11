using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using MovieApi.Application.Features.MediatorDesingPattern.Handlers.TagHandlers;
using MoviewApi.Persistence.Context;
using System.Reflection;

namespace MovieApi.WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServiceExtensions(this IServiceCollection services)
        {
            services.AddScoped<CreateCategoryCommandHandler>();
            services.AddScoped<UpdateCategoryCommandHandler>();
            services.AddScoped<RemoveCategoryCommandHandler>();
            services.AddScoped<GetCategoryQueryHandler>();
            services.AddScoped<GetCategoryByIdQueryHandler>();

            services.AddScoped<CreateMovieCommandHandler>();
            services.AddScoped<UpdateMovieCommandHandler>();
            services.AddScoped<RemoveMovieCommandHandler>();
            services.AddScoped<GetMovieQueryHandler>();
            services.AddScoped<GetMovieByIdQueryHandler>();

            //services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())); 9.0 ve altı için geçerli
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetTagQueryHandler).Assembly));
        }
    }
}
